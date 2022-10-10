namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task SaveAsync(string fileName, byte[] data);
    }
}
