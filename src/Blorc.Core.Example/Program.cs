using Blorc.Example;
using Blorc.Example.Shared;
using Blorc.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => new HttpClient
          {
              BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
          });

builder.Services.AddBlorcCore();
builder.Services.AddTransient<SurveyExecutionService>();
builder.Services.AddTransient<SurveyVisualizationService>();

var webAssemblyHost = builder.Build();

await webAssemblyHost
    .MapComponentServices(
        options =>
        {
            options.Map<SurveyPrompt, SurveyExecutionService>();
            options.Map<SurveyPrompt, SurveyVisualizationService>();
        })
    .ConfigureDocumentAsync(
        async documentService =>
        {
            await documentService.InjectBlorcCoreJsAsync();
        });

await webAssemblyHost.RunAsync();
