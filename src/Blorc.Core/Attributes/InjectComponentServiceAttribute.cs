namespace Blorc.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class InjectComponentServiceAttribute : Attribute
    {
        public InjectComponentServiceAttribute(string propertyName)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}
