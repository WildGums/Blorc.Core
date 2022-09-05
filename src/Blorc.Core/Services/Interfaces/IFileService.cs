// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task SaveAsync(string filename, byte[] data);
    }
}
