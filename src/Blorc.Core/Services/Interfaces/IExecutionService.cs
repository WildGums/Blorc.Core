namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IExecutionService : IComponentService
    {
        Task ExecuteAsync(object? state = null);
    }
}
