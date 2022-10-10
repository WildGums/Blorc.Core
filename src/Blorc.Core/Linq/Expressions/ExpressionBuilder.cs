﻿namespace Blorc.Linq.Expressions
{
    using System;
    using System.Linq.Expressions;
    using Blorc.Reflection;

    public static partial class ExpressionBuilder
    {
        // Note: cast or convert expression originally comes from https://tomsundev.wordpress.com/category/articles/set-or-get-fields-with-high-performance/
        private static Expression GetCastOrConvertExpression(Expression expression, Type targetType)
        {
            ArgumentNullException.ThrowIfNull(expression);
            ArgumentNullException.ThrowIfNull(targetType);

            Expression result;
            var expressionType = expression.Type;

            // Check if a cast or conversion is required.
            if (!targetType.IsAssignableFrom(expressionType))
            {
                // Check if we can use the as operator for casting or if we must use the convert method
                if (targetType.IsValueType && !targetType.IsNullableType())
                {
                    result = Expression.Convert(expression, targetType);
                }
                else
                {
                    result = Expression.TypeAs(expression, targetType);
                }
            }
            else
            {
                // Always hard cast, otherwise we might get exceptions while creating
                // the expressions
                result = Expression.Convert(expression, targetType);
            }

            return result;
        }
    }
}
