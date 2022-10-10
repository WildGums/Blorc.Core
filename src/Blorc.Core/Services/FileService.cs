namespace Blorc.Services
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.JSInterop;

    public class FileService : IFileService
    {
        private readonly IJSRuntime _jsRuntime;

        public FileService(IJSRuntime jsRuntime)
        {
            ArgumentNullException.ThrowIfNull(jsRuntime);

            _jsRuntime = jsRuntime;
        }

        public async Task SaveAsync(string fileName, byte[] data)
        {
            ArgumentNullException.ThrowIfNull(fileName);
            ArgumentNullException.ThrowIfNull(data);

            await _jsRuntime.InvokeAsync<object>("BlorcFile.SaveAs", fileName, Convert.ToBase64String(data));
        }
    }
}
