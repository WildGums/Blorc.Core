namespace Blorc.Services
{
    using System.Threading.Tasks;

    // ReSharper disable once InconsistentNaming
    public interface IUIVisualizationService : IComponentService
    {
        Task CloseAsync();

        Task ShowAsync();

        Task UpdateAsync();
    }
}
