﻿namespace Blorc.Linq.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static partial class ExpressionBuilder
    {
        public static Expression<Func<object, TProperty>>? CreatePropertyGetter<TProperty>(Type modelType, string propertyName)
        {
            ArgumentNullException.ThrowIfNull(modelType);
            ArgumentNullException.ThrowIfNull(propertyName);

            var property = modelType.GetProperty(propertyName);
            return property?.GetMethod is null ? null : CreatePropertyGetter<object, TProperty>(property);
        }

        public static Expression<Func<T, TProperty>>? CreatePropertyGetter<T, TProperty>(string propertyName)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            var property = typeof(T).GetProperty(propertyName);
            return property?.GetMethod is null ? null : CreatePropertyGetter<T, TProperty>(property);
        }

        public static Expression<Func<T, TProperty>>? CreatePropertyGetter<T, TProperty>(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetMethod is null ? null : CreatePropertyGetterExpression<T, TProperty>(propertyInfo);
        }

        public static Expression<Func<T, object>>? CreatePropertyGetter<T>(string propertyName)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            var property = typeof(T).GetProperty(propertyName);
            return property?.GetMethod is null ? null : CreatePropertyGetter<T>(property);
        }

        public static Expression<Func<T, object>>? CreatePropertyGetter<T>(PropertyInfo propertyInfo)
        {
            ArgumentNullException.ThrowIfNull(propertyInfo);

            return propertyInfo.GetMethod is null ? null : CreatePropertyGetterExpression<T, object>(propertyInfo);
        }

        public static IReadOnlyDictionary<string, Expression<Func<T, TProperty>>> CreatePropertyGetters<T, TProperty>()
        {
            var propertyGetters = new Dictionary<string, Expression<Func<T, TProperty>>>(StringComparer.OrdinalIgnoreCase);
            var properties = typeof(T).GetProperties().Where(w => w.GetMethod is not null && w.PropertyType == typeof(TProperty));

            foreach (var property in properties)
            {
                var propertyGetter = CreatePropertyGetter<T, TProperty>(property);
                if (propertyGetter is null)
                {
                    continue;
                }

                propertyGetters[property.Name] = propertyGetter;
            }

            return new ReadOnlyDictionary<string, Expression<Func<T, TProperty>>>(propertyGetters);
        }

        public static IReadOnlyDictionary<string, Expression<Func<T, object>>> CreatePropertyGetters<T>()
        {
            var propertyGetters = new Dictionary<string, Expression<Func<T, object>>>(StringComparer.OrdinalIgnoreCase);
            var properties = typeof(T).GetProperties().Where(w => w.GetMethod is not null);

            foreach (var property in properties)
            {
                var propertyGetter = CreatePropertyGetter<T>(property);
                if (propertyGetter is null)
                {
                    continue;
                }

                propertyGetters[property.Name] = propertyGetter;
            }

            return new ReadOnlyDictionary<string, Expression<Func<T, object>>>(propertyGetters);
        }

        private static Expression<Func<T, TProperty>>? CreatePropertyGetterExpression<T, TProperty>(PropertyInfo propertyInfo)
        {
            var targetType = propertyInfo.DeclaringType;
            var methodInfo = propertyInfo.GetMethod;

            if (targetType is null || methodInfo is null)
            {
                return null;
            }

            var target = Expression.Parameter(typeof(T), "target");
            var targetExpression = GetCastOrConvertExpression(target, targetType);

            var body = Expression.Call(targetExpression, methodInfo);

            var finalExpression = GetCastOrConvertExpression(body, typeof(TProperty));
#pragma warning disable HAA0101 // Array allocation for params parameter
            var lambda = Expression.Lambda<Func<T, TProperty>>(finalExpression, target);
#pragma warning restore HAA0101 // Array allocation for params parameter
            return lambda;
        }
    }
}
