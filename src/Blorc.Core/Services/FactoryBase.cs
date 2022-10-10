namespace Blorc.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FactoryBase : IFactory
    {
        private readonly IServiceProvider _provider;

        private readonly Dictionary<Type, List<Type>> _typeMappings = new Dictionary<Type, List<Type>>();

        public FactoryBase(IServiceProvider provider)
        {
            ArgumentNullException.ThrowIfNull(provider);

            _provider = provider;
        }

        public virtual IEnumerable Get(object source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var componentType = source.GetType();

            if (_typeMappings.TryGetValue(componentType, out var serviceTypes))
            {
                foreach (var serviceType in serviceTypes)
                {
                    yield return _provider.GetService(serviceType);
                }
            }
        }

        public virtual object? Get(object source, Type targetType)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(targetType);

            var componentType = source.GetType();

            if (_typeMappings.TryGetValue(componentType, out var serviceTypes))
            {
                var serviceType = serviceTypes.FirstOrDefault(targetType.IsAssignableFrom);
                if (serviceType is not null)
                {
                    return _provider.GetService(serviceType);
                }
            }

            return null;
        }

        public void Register(Type sourceType, Type targetType)
        {
            ArgumentNullException.ThrowIfNull(sourceType);
            ArgumentNullException.ThrowIfNull(targetType);

            if (!_typeMappings.ContainsKey(sourceType))
            {
                _typeMappings.Add(sourceType, new List<Type>());
            }

            _typeMappings[sourceType].Add(targetType);
        }
    }
}
