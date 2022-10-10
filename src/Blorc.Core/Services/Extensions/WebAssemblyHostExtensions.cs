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
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(options);

            var requiredService = @this.Services.GetRequiredService<IServiceProvider>();
            await options(requiredService);
        }

        public static async Task ConfigureDocumentAsync(this WebAssemblyHost @this, Func<IDocumentService, Task> options)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(options);

            await @this.ConfigureAsync(
                async provider =>
                {
                    var requiredService = @this.Services.GetRequiredService<IDocumentService>();
                    await options(requiredService);
                });
        }

        public static WebAssemblyHost MapComponentServices(this WebAssemblyHost @this, Action<IComponentServiceFactory> options)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(options);

            options.Invoke(@this.Services.GetRequiredService<IComponentServiceFactory>());
            return @this;
        }
    }
}
