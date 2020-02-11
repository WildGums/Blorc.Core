namespace Blorc.Example
{
    using System.Threading.Tasks;

    using Blorc.Example.Shared;
    using Blorc.Services;
   
    using Microsoft.AspNetCore.Blazor.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // TODO: Register component services...
            builder.Services.AddBlorcCore();
            builder.Services.AddTransient<SurveyExecutionService>();
            builder.Services.AddTransient<SurveyVisualizationService>();

            builder.RootComponents.Add<App>("app");


            var host = builder.Build();

            var componentServiceFactory = host.Services.GetService<IComponentServiceFactory>();
            componentServiceFactory.Map<SurveyPrompt, SurveyExecutionService>();
            componentServiceFactory.Map<SurveyPrompt, SurveyVisualizationService>();

            await host.RunAsync();
        }

    }
}
