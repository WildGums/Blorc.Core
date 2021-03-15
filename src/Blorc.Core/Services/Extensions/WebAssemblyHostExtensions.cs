namespace Blorc.Services
{
    using System;
    using System.Data;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebAssemblyHostExtensions
    {
        public static WebAssemblyHost MapComponentServices(this WebAssemblyHost @this, Action<IComponentServiceFactory> options)
        {
            options?.Invoke(@this.Services.GetRequiredService<IComponentServiceFactory>());
            return @this;
        } 

        public static WebAssemblyHost ConfigureDocument(this WebAssemblyHost @this, Action<IDocumentService> options)
        {
            options?.Invoke(@this.Services.GetRequiredService<IDocumentService>());
            return @this;
        } 
    }
}
