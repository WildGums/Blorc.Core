namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IConfigurationService
    {
        Task<T?> GetSectionAsync<T>(string sectionName);
    }
}
