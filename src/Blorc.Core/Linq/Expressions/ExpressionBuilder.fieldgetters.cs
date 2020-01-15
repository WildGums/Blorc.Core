﻿namespace Catel.Linq.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Catel.Reflection;

    public static partial class ExpressionBuilder
    {
        public static Expression<Func<object, TField>> CreateFieldGetter<TField>(Type modelType, string fieldName)
        {
            var field = modelType.GetField(fieldName);
            return field is null ? null : CreateFieldGetter<object, TField>(field);
        }

        public static Expression<Func<T, TField>> CreateFieldGetter<T, TField>(string fieldName)
        {
            var field = typeof(T).GetField(fieldName);
            return field is null ? null : CreateFieldGetter<T, TField>(field);
        }

        public static Expression<Func<T, TField>> CreateFieldGetter<T, TField>(FieldInfo fieldInfo)
        {
            return CreateFieldGetterExpression<T, TField>(fieldInfo);
        }

        public static Expression<Func<T, object>> CreateFieldGetter<T>(string fieldName)
        {
            var field = typeof(T).GetField(fieldName);
            return field is null ? null : CreateFieldGetter<T>(field);
        }

        public static Expression<Func<T, object>> CreateFieldGetter<T>(FieldInfo fieldInfo)
        {
            return fieldInfo is null ? null : CreateFieldGetterExpression<T, object>(fieldInfo);
        }

        public static IReadOnlyDictionary<string, Expression<Func<T, TField>>> CreateFieldGetters<T, TField>()
        {
            var fieldGetters = new Dictionary<string, Expression<Func<T, TField>>>(StringComparer.OrdinalIgnoreCase);
            var fields = typeof(T).GetFields().Where(w => w.FieldType == typeof(TField));

            foreach (var field in fields)
            {
                var fieldGetter = CreateFieldGetter<T, TField>(field);
                if (fieldGetter is null)
                {
                    continue;
                }

                fieldGetters[field.Name] = fieldGetter;
            }

            return new ReadOnlyDictionary<string, Expression<Func<T, TField>>>(fieldGetters);
        }

        public static IReadOnlyDictionary<string, Expression<Func<T, object>>> CreateFieldGetters<T>()
        {
            var fieldGetters = new Dictionary<string, Expression<Func<T, object>>>(StringComparer.OrdinalIgnoreCase);
            var fields = typeof(T).GetFields();

            foreach (var field in fields)
            {
                var fieldGetter = CreateFieldGetter<T>(field);
                if (fieldGetter is null)
                {
                    continue;
                }

                fieldGetters[field.Name] = fieldGetter;
            }

            return new ReadOnlyDictionary<string, Expression<Func<T, object>>>(fieldGetters);
        }

        private static Expression<Func<T, TField>> CreateFieldGetterExpression<T, TField>(FieldInfo fieldInfo)
        {
            var targetType = fieldInfo.DeclaringType;
            if (targetType is null)
            {
                return null;
            }

            var target = Expression.Parameter(typeof(T), "target");
            var targetExpression = GetCastOrConvertExpression(target, targetType);

            var body = Expression.Field(targetExpression, fieldInfo);

            var finalExpression = GetCastOrConvertExpression(body, typeof(TField));
            var lambda = Expression.Lambda<Func<T, TField>>(finalExpression, target);
            return lambda;
        }
    }
}
