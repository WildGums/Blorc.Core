namespace Blorc.Tests
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Blorc.StateConverters;
    using NUnit.Framework;
    using PublicApiGenerator;
    using VerifyNUnit;

    [TestFixture]
    public class PublicApiFacts
    {
        [Test, MethodImpl(MethodImplOptions.NoInlining)]
        public async Task Blorc_Core_HasNoBreakingChanges_Async()
        {
            var assembly = typeof(StateConverterContainer).Assembly;

            await PublicApiApprover.ApprovePublicApiAsync(assembly);
        }
    }

    internal static class PublicApiApprover
    {
        public static async Task ApprovePublicApiAsync(Assembly assembly)
        {
            var publicApi = assembly.GeneratePublicApi();
            await Verifier.Verify(publicApi);
        }
    }
}
