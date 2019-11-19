namespace Blorc.Dom.Injectors
{
   using Microsoft.JSInterop;
    using System.Threading.Tasks;

    using Serilog;

    internal static class StyleInjectorFunctionsInterop
    {
        public static Task<string> InjectHead(IJSRuntime jsRuntime, string value)
        {
            Log.Debug("Injecting head: '{Value}'", value);

            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "StyleInjectorFunctions.injectHead",
                value).AsTask();
        }
    }
}
