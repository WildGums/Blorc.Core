namespace Blorc.Example
{
    using Blorc.Example.Shared;
    using Blorc.Services;

    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void Configure(
            IComponentsApplicationBuilder app)
        {
            // Map the component service with components.
            app.UseComponentServices(
                options =>
                {
                    options.Map<SurveyPrompt, SurveyExecutionService>();
                    options.Map<SurveyPrompt, SurveyVisualizationService>();
                });

            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlorcCore();

            // TODO: Register component services...
            services.AddTransient<SurveyExecutionService>();
            services.AddTransient<SurveyVisualizationService>();
        }
    }
}
