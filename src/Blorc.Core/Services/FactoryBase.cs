// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryBase.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
            _provider = provider;
        }

        public virtual IEnumerable Get(object source)
        {
            var componentType = source.GetType();
            if (_typeMappings.TryGetValue(componentType, out var serviceTypes))
            {
                foreach (var serviceType in serviceTypes)
                {
                    yield return _provider.GetService(serviceType);
                }
            }
        }

        public virtual object Get(object source, Type targetType)
        {
            var componentType = source.GetType();
            if (_typeMappings.TryGetValue(componentType, out var serviceTypes))
            {
                var serviceType = serviceTypes.FirstOrDefault(targetType.IsAssignableFrom);
                if (serviceType != null)
                {
                    return _provider.GetService(serviceType);
                }
            }

            return null;
        }

        public void Register(Type sourceType, Type targetType)
        {
            if (!_typeMappings.ContainsKey(sourceType))
            {
                _typeMappings.Add(sourceType, new List<Type>());
            }

            _typeMappings[sourceType].Add(targetType);
        }
    }
}
