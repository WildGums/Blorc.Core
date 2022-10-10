namespace Blorc.StateConverters
{
    using System;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Fixed(this StateConverterContainer container, string value)
        {
            ArgumentNullException.ThrowIfNull(container);
            ArgumentNullException.ThrowIfNull(value);

            return container.Add(new FixedValueConverter(value));
        }

        public static StateConverterContainer If(this StateConverterContainer container, Func<bool>? predicate, string value)
        {
            ArgumentNullException.ThrowIfNull(container);
            ArgumentNullException.ThrowIfNull(value);

            return container.Add(new PredicateValueConverter(value, predicate));
        }

        public static StateConverterContainer If(this StateConverterContainer container, Func<bool>? predicate, Func<string> valueFunc)
        {
            ArgumentNullException.ThrowIfNull(container);
            ArgumentNullException.ThrowIfNull(valueFunc);

            return container.Add(new PredicateValueConverter(valueFunc, predicate));
        }
    }
}
