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

        public Task<Rect> GetBoundingClientRectAsync(double x, double y)
        {
            return DocumentInterop.GetBoundingClientRect(_jsRuntime, x, y);
        }

        public Task<Rect> GetBoundingClientRectByIdAsync(string id)
        {
            return DocumentInterop.GetBoundingClientRectById(_jsRuntime, id);
        }

        public Task<Rect> GetOffsetBoundingClientRectAsync(double x, double y)
        {
            return DocumentInterop.GetOffsetBoundingClientRect(_jsRuntime, x, y);
        }

        public async Task InjectScriptAsync(string source, string type = "text/javascript")
        {
            await InjectorInterop.InjectScript(_jsRuntime, source, type);
        }

        public async Task InjectLinkAsync(string href, string rel= "stylesheet", string type = "text/css")
        {
            await InjectorInterop.InjectLink(_jsRuntime, href, rel, type);
        }

        public async Task InjectHeadAsync(IInjectorValueProvider injectorValueProvider)
        {
            var value = injectorValueProvider.GetValue();
            await InjectorInterop.InjectHead(_jsRuntime, value);
        }
    }
}
