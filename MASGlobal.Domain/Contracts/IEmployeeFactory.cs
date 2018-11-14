using MASGlobal.Domain.Dtos;

namespace MASGlobal.Domain.Contracts
{
    public interface IEmployeeFactory
    {
        /// <summary>
        /// Generates the employee dto.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>An employee whose annual salary is based on his type of contract.</returns>
        EmployeeDto GenerateEmployeeDto(BaseEmployeeDto baseEmployee);
    }
}
