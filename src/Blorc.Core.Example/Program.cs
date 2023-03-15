using Blorc.Example;
using Blorc.Example.Shared;
using Blorc.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog.Core;
using Serilog.Extensions.Logging;
using Serilog;

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

// Logging
var levelSwitch = new LoggingLevelSwitch
{
#if DEBUG
    MinimumLevel = Serilog.Events.LogEventLevel.Debug
#else
    MinimumLevel = Serilog.Events.LogEventLevel.Information
#endif
};

var logger = Log.Logger = new LoggerConfiguration()
    .MinimumLevel.ControlledBy(levelSwitch)
    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
    .WriteTo.BrowserConsole()
    .CreateLogger();

builder.Services.AddSingleton<ILoggerFactory>(new SerilogLoggerFactory(logger, false));
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

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
