namespace Blorc.Dom.Injectors
{
    using Microsoft.JSInterop;
    using System.Threading.Tasks;

    internal static class InjectorInterop
    {
        public static Task<string> InjectHead(IJSRuntime jsRuntime, string value)
        {
            return jsRuntime.InvokeAsync<string>(
                "BlorcInjector.injectHead",
                value).AsTask();
        }

        public static Task<string> InjectScript(IJSRuntime jsRuntime, string source, string type)
        {
            return jsRuntime.InvokeAsync<string>(
                "BlorcInjector.injectScript",
                source, type).AsTask();
        }
    }
}
