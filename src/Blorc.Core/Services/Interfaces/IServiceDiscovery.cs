namespace Blorc.Services
{
    using System.Threading.Tasks;

    /// <summary>
    ///     The ServiceDiscovery interface.
    /// </summary>
    public interface IServiceDiscovery
    {
        /// <summary>
        ///     Gets service end point.
        /// </summary>
        /// <param name="serviceName">
        ///     The service name.
        /// </param>
        /// <param name="bindingIndex">
        ///     The idx.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        Task<string> GetServiceEndPointAsync(string serviceName, int bindingIndex = 0);

        /// <summary>
        ///     Gets service end point.
        /// </summary>
        /// <param name="serviceName">
        ///     The service name.
        /// </param>
        /// <param name="bindingName">
        ///     The binding name.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        Task<string> GetServiceEndPointAsync(string serviceName, string bindingName);
    }
}
