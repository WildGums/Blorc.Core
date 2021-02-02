namespace Blorc.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Serilog;

    public class ConfigurationService : IConfigurationService
    {
        private readonly NavigationManager _navigationManager;

        private readonly Dictionary<string, string> _parameters;

        public ConfigurationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _parameters = new Dictionary<string, string>();

            Initialize();
        }

        public async Task<T> GetSectionAsync<T>(string sectionName)
        {
            _parameters.TryGetValue("env", out var environment);

            using (var httpClient = new HttpClient())
            {
                var requestUrl = _navigationManager.BaseUri + "api/.configuration/" + (string.IsNullOrWhiteSpace(environment) ? $"{sectionName}.json" : $"{sectionName}.{environment}.json");
                try
                {
                    var configuration = await httpClient.GetStringAsync(requestUrl);
                    return JsonSerializer.Deserialize<T>(configuration);
                }
                catch (Exception e)
                {
                    // TODO: Use logger instead.
                    Log.Error($"Error reading configuration section {sectionName} : {e.Message}");
                    return default;
                }
            }
        }

        private void Initialize()
        {
            var absoluteUri = _navigationManager.Uri;
            var splittedUrl = absoluteUri.Split('?');
            if (splittedUrl.Length == 2)
            {
                var parameters = splittedUrl[1].Split('&', '#');
                foreach (var parameter in parameters)
                {
                    var splittedQueryString = parameter.Split('=');
                    if (splittedQueryString.Length == 2)
                    {
                        _parameters.Add(splittedQueryString[0], splittedQueryString[1]);
                    }
                }
            }
        }
    }
}
