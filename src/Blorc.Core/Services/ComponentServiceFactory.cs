namespace Blorc.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Components;

    public class ComponentServiceFactory : FactoryBase, IComponentServiceFactory
    {
        public ComponentServiceFactory(IServiceProvider provider)
            : base(provider)
        {
        }

        public override IEnumerable Get(object source)
        {
            foreach (var service in Get<IComponentService>((ComponentBase)source))
            {
                yield return service;
            }
        }

        public IEnumerable<TComponentService> Get<TComponentService>(ComponentBase componentBase)
            where TComponentService : IComponentService
        {
            ArgumentNullException.ThrowIfNull(componentBase);

            foreach (var componentService in base.Get(componentBase).OfType<TComponentService>())
            {
                componentService.Component = componentBase;
                yield return componentService;
            }
        }

        public TComponentService Get<TComponentService>(ComponentBase componentBase, Type targetType)
            where TComponentService : IComponentService
        {
            ArgumentNullException.ThrowIfNull(componentBase);
            ArgumentNullException.ThrowIfNull(targetType);

            var componentService = (TComponentService?)base.Get(componentBase, targetType);
            if (componentService is null)
            {
                throw new InvalidOperationException($"Cannot create component service for target type '{targetType.Name}'");
            }

            componentService.Component = componentBase;
            return componentService;
        }

        public override object? Get(object source, Type targetType)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(targetType);

            return Get<IComponentService>((ComponentBase)source, targetType);
        }

        public void Map<TComponent, TComponentService>()
            where TComponent : ComponentBase where TComponentService : IComponentService
        {
            base.Register(typeof(TComponent), typeof(TComponentService));
        }
    }
}
