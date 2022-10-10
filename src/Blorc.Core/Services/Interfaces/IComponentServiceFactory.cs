namespace Blorc.Services
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;

    public interface IComponentServiceFactory : IFactory
    {
        IEnumerable<TComponentService> Get<TComponentService>(ComponentBase componentBase)
            where TComponentService : IComponentService; 
        
        void Map<TComponent, TService>()
            where TComponent : ComponentBase where TService : IComponentService;

        TComponentService Get<TComponentService>(ComponentBase componentBase, Type targetType)
            where TComponentService : IComponentService;
    }
}
