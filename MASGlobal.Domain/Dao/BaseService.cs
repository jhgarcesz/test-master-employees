using RestSharp;

namespace MASGlobal.Domain.Dao
{
    public abstract class BaseService
    {
        /// <summary>
        /// Generates the rest request.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="method">The method.</param>
        /// <returns>A RestRequest.</returns>
        internal RestRequest GenerateRestRequest(string resource, Method method) => new RestRequest(resource, method);
    }
}
