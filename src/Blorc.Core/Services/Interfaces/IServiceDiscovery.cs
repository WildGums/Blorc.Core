// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceDiscovery.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.Services.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The ServiceDiscovery interface.
    /// </summary>
    public interface IServiceDiscovery
    {
        /// <summary>
        /// Gets service end point.
        /// </summary>
        /// <param name="serviceName">
        /// The service name.
        /// </param>
        /// <param name="idx">
        /// The idx.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> GetServiceEndPoint(string serviceName, int idx = 0);
    }
}
