namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task SaveAsync(string filename, byte[] data);
    }
}
