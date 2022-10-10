namespace Blorc.Services
{
    using System;
    using System.Threading.Tasks;

    public static class IConfigurationServiceExtensions
    {
        public static async Task<T?> GetRequiredSectionAsync<T>(this IConfigurationService configurationService, string sectionName)
        {
            ArgumentNullException.ThrowIfNull(configurationService);
            ArgumentNullException.ThrowIfNull(sectionName);

            var section = await configurationService.GetSectionAsync<T>(sectionName);
            if (section is null)
            {
                throw new InvalidOperationException($"Cannot retrieve required configuration section '{sectionName}'");
            }

            return section;
        }
    }
}
