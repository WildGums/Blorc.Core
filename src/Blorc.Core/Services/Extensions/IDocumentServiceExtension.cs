namespace Blorc.Services
{
    using System.Reflection;
    using System.Threading.Tasks;

    public static class IDocumentServiceExtension
    {
        public static async Task InjectAssemblyScriptFile(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            await @this.InjectScript(source);
        }

        public static async Task InjectBlorcCoreJS(this IDocumentService @this)
        {
            await @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "document.js");
            await @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "file.js");
        }
    }
}
