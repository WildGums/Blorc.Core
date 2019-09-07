namespace Blorc.Services.Interop
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    internal static class DocumentFunctionsInterop
    {
        public static Task<Rect> GetBoundingClientRect(IJSRuntime jsRuntime, double x, double y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getBoundingClientRect",
                x, y).AsTask();
        }

        public static Task<Rect> GetOffsetBoundingClientRect(IJSRuntime jsRuntime, double x, double y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getOffsetBoundingClientRect",
                x, y).AsTask();
        }

        public static Task<Rect> GetBoundingClientRectById(IJSRuntime jsRuntime, string id)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "DocumentFunctions.getBoundingClientRectById",
                id).AsTask();
        }
    }

    public class Rect
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Bottom { get; set; }

        public double Top { get; set; }
    }
}
