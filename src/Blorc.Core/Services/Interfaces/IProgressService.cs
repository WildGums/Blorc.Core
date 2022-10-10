namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IProgressService<T>
    {
        Task ReportAsync(T value);
    }
}
