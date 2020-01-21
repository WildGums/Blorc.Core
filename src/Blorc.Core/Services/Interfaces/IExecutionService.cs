// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExecutionService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IExecutionService
    {
        Task ExecuteAsync(object state = null);
    }
}
