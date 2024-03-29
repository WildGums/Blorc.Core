﻿#pragma warning disable CL0002 // Use "Async" suffix for async methods

namespace Blorc.Services.Interop
{
    using System.Threading.Tasks;

    using Microsoft.JSInterop;

    internal static class DocumentInterop
    {
        public static Task<Rect> GetBoundingClientRect(IJSRuntime jsRuntime, double x, double y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "BlorcDocument.getBoundingClientRect",
                x,
                y).AsTask();
        }

        public static Task<Rect> GetBoundingClientRectById(IJSRuntime jsRuntime, string id)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "BlorcDocument.getBoundingClientRectById",
                id).AsTask();
        }

        public static Task<Rect> GetOffsetBoundingClientRect(IJSRuntime jsRuntime, double x, double y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "BlorcDocument.getOffsetBoundingClientRect",
                x,
                y).AsTask();
        }
    }

    public class Rect
    {
        public double Bottom { get; set; }

        public double Height { get; set; }

        public double Top { get; set; }

        public double Width { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
