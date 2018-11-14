using MASGlobal.Domain.Contracts;
using MASGlobal.Domain.Dtos;
using MASGlobal.Domain.Support;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace MASGlobal.Domain.Dao
{
    public class EmployeeRepository : BaseService, IEmployeeRepository
    {
        private readonly IRestClient restClient;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="restClient">The rest client.</param>
        public EmployeeRepository(IRestClient restClient)
        {
            this.restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>
        /// A list of employees.
        /// </returns>
        public async Task<IEnumerable<BaseEmployeeDto>> GetAllEmployees()
        {
            var request = GenerateRestRequest(Constants.GetAllRoute, Method.GET);

            request.RequestFormat = DataFormat.Json;

            var tcs = new TaskCompletionSource<IRestResponse>();

            restClient.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    tcs.TrySetException(response.ErrorException);
                }
                else if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    tcs.TrySetException(new HttpException($"Error calling reviews service: {response.Content}, StatusCode: {(int)response.StatusCode}, Reason: {response.StatusDescription}"));
                }
                else
                {
                    tcs.TrySetResult(response);
                }
            });

            var clientResponse = await tcs.Task;
            var responseDto = JsonConvert.DeserializeObject<List<BaseEmployeeDto>>(clientResponse.Content);

            return responseDto;

            /*
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var ex = new EmployeeServiceException(Convert.ToInt32(response.StatusCode), "");
                throw ex;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseDto = JsonConvert.DeserializeObject<List<BaseEmployeeDto>>(response.Content);
                return responseDto;
            }

            //create own exception
            throw new Exception("General error calling the employee service"); */
        }

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An employee dto.
        /// </returns>
        public async Task<BaseEmployeeDto> GetEmployeeById(int id)
        {
            var employees = await GetAllEmployees();

            return employees.Any() ? employees.FirstOrDefault(e => e.Id.Equals(id)) : null;
        }
    }
}
