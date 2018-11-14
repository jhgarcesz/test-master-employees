using MASGlobal.Domain.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MASGlobal.Web.Controllers
{
    /// <summary>
    /// Represents the employee controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService employeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeService">The employee service.</param>
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var employees = await employeeService.GetAllEmployees();

            return employees.Any() ? (IHttpActionResult)Ok(employees) : NotFound();
        }

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        /// <returns>An specific employee.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var employee = await employeeService.GetEmployeeById(id);

            return employee is null ? (IHttpActionResult)NotFound() : Ok(employee);
        }
    }
}
