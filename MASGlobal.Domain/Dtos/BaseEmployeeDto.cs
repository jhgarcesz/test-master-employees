namespace MASGlobal.Domain.Dtos
{
    public class BaseEmployeeDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the contract type.
        /// </summary>
        public string ContractTypeName { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or sets the hourly salary.
        /// </summary>
        public double HourlySalary { get; set; }

        /// <summary>
        /// Gets or sets the monthly salary.
        /// </summary>
        public double MonthlySalary { get; set; }
    }
}
