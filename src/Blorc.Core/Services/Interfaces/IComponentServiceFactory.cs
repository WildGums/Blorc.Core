// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComponentServiceFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

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
