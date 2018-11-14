using MASGlobal.Domain.Contracts;
using MASGlobal.Domain.Dtos;
using MASGlobal.Domain.Enums;
using System;

namespace MASGlobal.Domain.Domain
{
    public class EmployeeFactory : IEmployeeFactory
    {
        /// <summary>
        /// Generates the employee dto.
        /// </summary>
        /// <param name="baseEmployee"></param>
        /// <returns>
        /// An employee whose annual salary is based on his type of contract.
        /// </returns>
        public EmployeeDto GenerateEmployeeDto(BaseEmployeeDto baseEmployee)
        {
            var employeeDto = new EmployeeDto
            {
                Id = baseEmployee.Id,
                ContractTypeName = baseEmployee.ContractTypeName,
                HourlySalary = baseEmployee.HourlySalary,
                MonthlySalary = baseEmployee.MonthlySalary,
                Name = baseEmployee.Name,
                RoleDescription = baseEmployee.RoleDescription,
                RoleId = baseEmployee.RoleId,
                RoleName = baseEmployee.RoleName
            };

            switch (GetEnumContractType(baseEmployee.ContractTypeName))
            {
                case EmployeeContractType.HourlySalaryEmployee:
                    employeeDto.AnnualSalary = 120 * employeeDto.HourlySalary * 12;
                    break;
                case EmployeeContractType.MonthlySalaryEmployee:
                    employeeDto.AnnualSalary = employeeDto.MonthlySalary * 12;
                    break;
            }

            return employeeDto;
        }

        /// <summary>
        /// Gets the enum of the contract type.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>Contract type enum.</returns>
        EmployeeContractType GetEnumContractType(string contractType)
        {
            if (!Enum.TryParse(contractType, out EmployeeContractType contractTypeEnum))
            {
                throw new InvalidOperationException("Invalid contract type");
            }

            return contractTypeEnum;
        }
    }
}
