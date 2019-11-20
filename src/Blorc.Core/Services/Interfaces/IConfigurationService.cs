// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationService.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services
{
    using System.Threading.Tasks;

    public interface IConfigurationService
    {
        Task<T> GetSection<T>(string sectionName);
    }
}
