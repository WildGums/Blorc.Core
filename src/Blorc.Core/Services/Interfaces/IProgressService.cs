// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProgressService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IProgressService<T>
    {
        Task ReportAsync(T value);
    }
}
