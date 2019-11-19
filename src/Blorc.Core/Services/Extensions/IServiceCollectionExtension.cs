namespace Blorc.Services
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static void AddBlorc(this IServiceCollection @this)
        {
            @this.AddSingleton<IDocumentService, DocumentService>();
            @this.AddSingleton<IConfigurationService, ConfigurationService>();
            @this.AddSingleton<IFileService, FileService>();
        }
    }
}
