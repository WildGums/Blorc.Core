namespace Blorc.Services
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebAssemblyHostExtensions
    {
        public static async Task ConfigureAsync(this WebAssemblyHost @this, Func<IServiceProvider, Task> options)
        {
            var requiredService = @this.Services.GetRequiredService<IServiceProvider>();
            await options(requiredService);
            await @this.RunAsync();
        }

        public static async Task ConfigureDocumentAsync(this WebAssemblyHost @this, Func<IDocumentService, Task> options)
        {
            var requiredService = @this.Services.GetRequiredService<IDocumentService>();
            await options(requiredService);
            await @this.RunAsync();
        }

        public static WebAssemblyHost MapComponentServices(this WebAssemblyHost @this, Action<IComponentServiceFactory> options)
        {
            options?.Invoke(@this.Services.GetRequiredService<IComponentServiceFactory>());
            return @this;
        }
    }
}
