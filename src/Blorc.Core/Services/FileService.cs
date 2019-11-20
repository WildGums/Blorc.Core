// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// <summary>
//   Defines the FileService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
            _jsRuntime = jsRuntime;
        }

        public async Task SaveAsync(string filename, byte[] data)
        {
            await _jsRuntime.InvokeAsync<object>("FileService.SaveAs", filename, Convert.ToBase64String(data));
        }
    }
}
