namespace Blorc.Services
{
    using System.Threading.Tasks;
    using Blorc.Dom.Injectors;
    using Interop;

    public interface IDocumentService
    {
        Task<Rect> GetBoundingClientRectById(string id);

        Task<Rect> GetOffsetBoundingClientRect(double x, double y);

        Task<Rect> GetBoundingClientRect(double x, double y);

        void InjectHead(IInjectorValueProvider injectorValueProvider);
    }
}
