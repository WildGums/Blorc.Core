namespace Blorc.Services
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static void AddBlorcCore(this IServiceCollection @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AddSingleton<IDocumentService, DocumentService>();
            @this.AddSingleton<IConfigurationService, ConfigurationService>();
            @this.AddSingleton<IFileService, FileService>();
            @this.AddSingleton<IComponentServiceFactory, ComponentServiceFactory>();
        }
    }
}
