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
        public static async Task InjectAssemblyCSSFile(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            await @this.InjectLink(source);
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
        public static async Task InjectAssemblyScriptFile(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            await @this.InjectScript(source);
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
        public static async Task InjectBlorcCoreJS(this IDocumentService @this)
        {
            await @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "document.js");
            await @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "file.js");
        }
    }
}
