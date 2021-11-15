#pragma warning disable CL0002 // Use "Async" suffix for async methods

namespace Blorc.Dom.Injectors
{
    using System.Threading.Tasks;

    using Microsoft.JSInterop;

    internal static class InjectorInterop
    {
        public static Task<string> InjectHead(IJSRuntime jsRuntime, string value)
        {
            return jsRuntime.InvokeAsync<string>(
                "BlorcInjector.injectHead",
                value).AsTask();
        }

        public static Task<string> InjectLink(IJSRuntime jsRuntime, string href, string rel, string type)
        {
            return jsRuntime.InvokeAsync<string>(
                "BlorcInjector.injectLink",
                href, 
                rel, 
                type).AsTask();
        }

        public static Task<string> InjectScript(IJSRuntime jsRuntime, string source, string type)
        {
            return jsRuntime.InvokeAsync<string>(
                "BlorcInjector.injectScript",
                source,
                type).AsTask();
        }
    }
}
