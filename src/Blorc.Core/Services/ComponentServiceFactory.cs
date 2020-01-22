// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComponentServiceBaseFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
            foreach (var componentService in base.Get(componentBase).OfType<TComponentService>())
            {
                componentService.Component = componentBase;
                yield return componentService;
            }
        }

        public TComponentService Get<TComponentService>(ComponentBase componentBase, Type targetType)
            where TComponentService : IComponentService
        {
            var componentService = (TComponentService)base.Get(componentBase, targetType);
            componentService.Component = componentBase;
            return componentService;
        }

        public void Map<TComponent, TComponentService>()
            where TComponent : ComponentBase where TComponentService : IComponentService
        {
            base.Register(typeof(TComponent), typeof(TComponentService));
        }
    }
}
