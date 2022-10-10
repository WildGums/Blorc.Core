namespace Blorc.StateConverters
{
    using System;
    using System.Linq.Expressions;
    using Blorc.Linq.Expressions;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Watch<TProperty>(this StateConverterContainer container, Expression<Func<TProperty>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(container);
            ArgumentNullException.ThrowIfNull(propertyExpression);

            var owner = ExpressionHelper.GetOwner(propertyExpression);
            if (owner is null)
            {
                throw new InvalidOperationException("Cannot retrieve owner from property expression");
            }

            var propertyName = ExpressionHelper.GetPropertyName(propertyExpression);
            if (propertyName is null)
            {
                throw new InvalidOperationException("Cannot retrieve property name from property expression");
            }

            return container.Add(new PropertyStateWatcher(owner, propertyName));
        }
    }
}
