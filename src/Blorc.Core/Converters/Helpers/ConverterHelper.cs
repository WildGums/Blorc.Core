namespace Blorc.Converters
{
    public static class ConverterHelper
    {
        private static readonly object _unsetValue = new object();

        public static object UnsetValue { get { return _unsetValue; } }
    }
}
