﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System.Threading.Tasks;

    using Blorc.Dom.Injectors;
    using Blorc.Services.Interop;

    /// <summary>
    /// The DocumentService interface.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// The get bounding client rect.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Rect> GetBoundingClientRect(double x, double y);

        /// <summary>
        /// The get bounding client rect by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Rect> GetBoundingClientRectById(string id);

        /// <summary>
        /// The get offset bounding client rect.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Rect> GetOffsetBoundingClientRect(double x, double y);

        /// <summary>
        /// The inject head.
        /// </summary>
        /// <param name="injectorValueProvider">
        /// The injector value provider.
        /// </param>
        void InjectHead(IInjectorValueProvider injectorValueProvider);

        /// <summary>
        /// The inject link.
        /// </summary>
        /// <param name="href">
        /// The href.
        /// </param>
        /// <param name="rel">
        /// The rel.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task InjectLink(string href, string rel = "stylesheet", string type = "text/css");

        /// <summary>
        /// The inject script.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task InjectScript(string source, string type = "text/javascript");
    }
}
