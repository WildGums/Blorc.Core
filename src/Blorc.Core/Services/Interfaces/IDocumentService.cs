// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System.Threading.Tasks;

    using Blorc.Dom.Injectors;
    using Blorc.Services.Interop;

    public interface IDocumentService
    {
        Task<Rect> GetBoundingClientRect(double x, double y);

        Task<Rect> GetBoundingClientRectById(string id);

        Task<Rect> GetOffsetBoundingClientRect(double x, double y);

        void InjectHead(IInjectorValueProvider injectorValueProvider);

        void InjectScript(string source, string type = "text/javascript");
    }
}
