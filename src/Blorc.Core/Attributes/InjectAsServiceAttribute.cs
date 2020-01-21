namespace Blorc.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InjectAsServiceAttribute : Attribute
    {
        public InjectAsServiceAttribute(Type serviceType, string propertyName)
        {
            ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
            PropertyName = !string.IsNullOrWhiteSpace(propertyName) ? propertyName : throw new ArgumentNullException(nameof(propertyName));
        }

        public string PropertyName { get; }

        public Type ServiceType { get; }
    }
}
