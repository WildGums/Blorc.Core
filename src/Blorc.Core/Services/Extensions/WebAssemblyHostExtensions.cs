namespace Blorc.Services
{
    using System;
    using Microsoft.AspNetCore.Blazor.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebAssemblyHostExtensions
    {
        public static WebAssemblyHost MapComponentServices(this WebAssemblyHost @this, Action<IComponentServiceFactory> options)
        {
            options?.Invoke(@this.Services.GetService<IComponentServiceFactory>());
            return @this;
        } 
    }
}
