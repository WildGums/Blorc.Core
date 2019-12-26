namespace Blorc.Services
{
    using System.Threading.Tasks;

    using Blorc.Dom.Injectors;
    using Blorc.Services.Interop;

    using Microsoft.JSInterop;

    public class DocumentService : IDocumentService
    {
        private readonly IJSRuntime _jsRuntime;

        public DocumentService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<Rect> GetBoundingClientRect(double x, double y)
        {
            return DocumentInterop.GetBoundingClientRect(_jsRuntime, x, y);
        }

        public Task<Rect> GetBoundingClientRectById(string id)
        {
            return DocumentInterop.GetBoundingClientRectById(_jsRuntime, id);
        }

        public Task<Rect> GetOffsetBoundingClientRect(double x, double y)
        {
            return DocumentInterop.GetOffsetBoundingClientRect(_jsRuntime, x, y);
        }

        public void InjectScript(string source, string type = "text/javascript")
        {
            InjectorInterop.InjectScript(_jsRuntime, source, type);
        }

        public void InjectHead(IInjectorValueProvider injectorValueProvider)
        {
            var value = injectorValueProvider.GetValue();
            InjectorInterop.InjectHead(_jsRuntime, value);
        }
    }
}
