namespace Blorc.Services
{
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// The document service extension.
    /// </summary>
    public static class IDocumentServiceExtension
    {
        /// <summary>
        /// The inject assembly css file.
        /// </summary>
        /// <param name="this">
        /// The this.
        /// </param>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task InjectAssemblyCssFileAsync(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            await @this.InjectLinkAsync(source);
        }

        /// <summary>
        /// The inject assembly script file.
        /// </summary>
        /// <param name="this">
        /// The this.
        /// </param>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task InjectAssemblyScriptFileAsync(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            await @this.InjectScriptAsync(source);
        }

        /// <summary>
        /// The inject blorc core js.
        /// </summary>
        /// <param name="this">
        /// The this.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task InjectBlorcCoreJsAsync(this IDocumentService @this)
        {
            await @this.InjectAssemblyScriptFileAsync(typeof(IDocumentServiceExtension).Assembly, "document.js");
            await @this.InjectAssemblyScriptFileAsync(typeof(IDocumentServiceExtension).Assembly, "file.js");
        }
    }
}
