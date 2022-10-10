namespace Blorc.Bindings
{
    using System;
    using System.Linq.Expressions;
    using Blorc.Converters;
    using Blorc.Linq.Expressions;

    public class BindingBuilder
    {
        private readonly BindingContext _bindingContext;

        private object? _source;
        private string? _sourceProperty;

        private object? _target;
        private string? _targetProperty;

        private BindingMode _bindingMode = BindingMode.OneWay;
        private IValueConverter? _converter;

        internal BindingBuilder(BindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            _bindingContext = bindingContext;
        }

        public BindingBuilder From<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _source = ExpressionHelper.GetOwner(propertyExpression);
            _sourceProperty = ExpressionHelper.GetPropertyName(propertyExpression);

            return this;
        }

        public BindingBuilder To<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _target = ExpressionHelper.GetOwner(propertyExpression);
            _targetProperty = ExpressionHelper.GetPropertyName(propertyExpression);

            return this;
        }

        public BindingBuilder AsMode(BindingMode mode)
        {
            _bindingMode = mode;

            return this;
        }

        public BindingBuilder UsingConverter(IValueConverter valueConverter)
        {
            ArgumentNullException.ThrowIfNull(valueConverter);

            _converter = valueConverter;

            return this;
        }

        public void Apply()
        {
            _bindingContext.AddBinding(this);
        }

        public static implicit operator Binding(BindingBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            if (builder._source is null)
            {
                throw new InvalidOperationException("Builder Source is null");
            }

            if (builder._sourceProperty is null)
            {
                throw new InvalidOperationException("Builder Source Property is null");
            }

            if (builder._target is null)
            {
                throw new InvalidOperationException("Builder Target is null");
            }

            if (builder._targetProperty is null)
            {
                throw new InvalidOperationException("Builder Target Property is null");
            }

            var binding = new Binding(
                new BindingParty(builder._source, builder._sourceProperty),
                new BindingParty(builder._target, builder._targetProperty),
                builder._bindingMode,
                builder._converter);

            return binding;
        }
    }
}
