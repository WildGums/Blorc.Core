namespace Blorc.StateConverters
{
    using System;

    public sealed class FixedValueConverter : IStateConverter
    {
        private readonly string _fixedValue;

        public FixedValueConverter(string fixedValue)
        {
            ArgumentNullException.ThrowIfNull(fixedValue);

            _fixedValue = fixedValue;
        }

        public void Dispose()
        {
            // not required
        }

        public string GetValue()
        {
            return _fixedValue;
        }
    }
}
