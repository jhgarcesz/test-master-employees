using MASGlobal.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASGlobal.Domain.Contracts
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        Task<IEnumerable<BaseEmployeeDto>> GetAllEmployees();

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An especific employee.</returns>
        Task<BaseEmployeeDto> GetEmployeeById(int id);
    }
}
