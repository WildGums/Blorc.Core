namespace Blorc.Services
{
    using System;
    using System.Reflection;
    using Serilog;

    public static class IDocumentServiceExtension
    {
        public static void InjectAssemblyScriptFile(this IDocumentService @this, Assembly assembly, string path)
        {
            var source = $"_content/{assembly.GetName().Name}/{path}";
            @this.InjectScript(source);
        }

        public static void InjectBlorcCoreJS(this IDocumentService @this)
        {
            @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "document.js");
            @this.InjectAssemblyScriptFile(typeof(IDocumentServiceExtension).Assembly, "file.js");
        }
    }
}
