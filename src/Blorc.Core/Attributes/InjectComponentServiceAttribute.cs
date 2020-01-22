namespace Blorc.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class InjectComponentServiceAttribute : Attribute
    {
        public InjectComponentServiceAttribute(string propertyName)
        {
            PropertyName = !string.IsNullOrWhiteSpace(propertyName) ? propertyName : throw new ArgumentNullException(nameof(propertyName));
        }

        public string PropertyName { get; }
    }
}
