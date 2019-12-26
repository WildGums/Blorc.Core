namespace Blorc.Example
{
    using Blorc.Dom.Injectors;
    using Blorc.Example;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlorcCore();
        }

        public void Configure(IComponentsApplicationBuilder app, IDocumentService documentService)
        {
            documentService.InjectBlorcCoreJS();
            documentService.InjectHead(new Css("/patternfly/patternfly.css"));

            app.AddComponent<App>("app");
        }
    }
}
