// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComponentsApplicationBuilderExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System;

    using Blorc.Services;

    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class IComponentsApplicationBuilderExtensions
    {
        public static void UseComponentServices(this IComponentsApplicationBuilder @this, Action<IComponentServiceFactory> action)
        {
            action(@this.Services.GetService<IComponentServiceFactory>());
        }
    }
}
