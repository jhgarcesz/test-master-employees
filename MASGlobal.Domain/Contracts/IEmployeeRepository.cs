using MASGlobal.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASGlobal.Domain.Contracts
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An employee dto.</returns>
        Task<BaseEmployeeDto> GetEmployeeById(int id);

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        Task<IEnumerable<BaseEmployeeDto>> GetAllEmployees();

    }
}
