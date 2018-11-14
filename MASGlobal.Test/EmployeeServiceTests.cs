using MASGlobal.Domain.Contracts;
using MASGlobal.Domain.Domain;
using MASGlobal.Domain.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASGlobal.Tests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeFactory> mockedFactory;
        private Mock<IEmployeeRepository> mockedRepository;
        private EmployeeService employeeService;
        
        [TestInitialize]
        public void Initialize()
        {
            mockedFactory = new Mock<IEmployeeFactory>();
            mockedRepository = new Mock<IEmployeeRepository>();

            mockedFactory.Setup(x => x.GenerateEmployeeDto(It.IsAny<BaseEmployeeDto>()))
                .Returns(() => new EmployeeDto
                {
                    Id = 1234,
                    Name = "Jhorx Garces"
                });

            employeeService = new EmployeeService(mockedRepository.Object, mockedFactory.Object);
        }

        [TestMethod]
        public async Task EmployeeService_GetAllEmployees_WillReturnData()
        {
            //Arrange
            mockedRepository.Setup(x => x.GetAllEmployees())
                .ReturnsAsync(() => new List<BaseEmployeeDto>()
                {
                    new BaseEmployeeDto
                    {
                        Id = 234,
                        Name = "Michael"
                    },
                    new BaseEmployeeDto
                    {
                        Id = 098,
                        Name = "Peter"
                    }
                });

            //Act
            var result = await employeeService.GetAllEmployees();

            //Assert
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
