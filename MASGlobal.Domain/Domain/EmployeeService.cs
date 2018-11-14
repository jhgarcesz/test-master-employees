using MASGlobal.Domain.Contracts;
using MASGlobal.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASGlobal.Domain.Domain
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeFactory employeeFactory;
        private readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.employeeFactory = employeeFactory ?? throw new ArgumentNullException(nameof(employeeFactory));
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>
        /// List of employees.
        /// </returns>
        public async Task<IEnumerable<BaseEmployeeDto>> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAllEmployees();

            if (employees is null || !employees.Any())
            {
                return new List<BaseEmployeeDto>();
            }

            return employees.Select(e => employeeFactory.GenerateEmployeeDto(e));
        }

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An especific employee.
        /// </returns>
        public async Task<BaseEmployeeDto> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetEmployeeById(id);

            return employee is null ? null : employeeFactory.GenerateEmployeeDto(employee);
        }
    }
}
