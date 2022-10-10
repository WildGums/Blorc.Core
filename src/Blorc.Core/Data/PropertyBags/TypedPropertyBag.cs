namespace Blorc.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Memory efficient typed property bag that takes care of boxing.
    /// </summary>
    public partial class TypedPropertyBag : PropertyBagBase
    {
        private readonly Dictionary<string, Type> _propertyTypes = new Dictionary<string, Type>();

        public override string[] GetAllNames()
        {
            lock (_propertyTypes)
            {
                return _propertyTypes.Keys.ToArray();
            }
        }

        public override bool IsAvailable(string name)
        {
            lock (_propertyTypes)
            {
                return _propertyTypes.ContainsKey(name);
            }
        }

        private Type? GetRegisteredPropertyType(string name)
        {
            lock (_propertyTypes)
            {
                if (_propertyTypes.TryGetValue(name, out var existingType))
                {
                    return existingType;
                }
            }

            return null;
        }

        private void EnsureIntegrity(string name, Type type)
        {
            lock (_propertyTypes)
            {
                if (_propertyTypes.TryGetValue(name, out var existingType))
                {
                    if (existingType != type && !existingType.IsAssignableFrom(type))
                    {
                        throw new InvalidOperationException($"Property '{name}' is already registered as '{existingType.FullName}' which is not compatible with '{type.FullName}'");
                    }
                }
                else
                {
                    _propertyTypes[name] = type;
                }
            }
        }
    }
}
