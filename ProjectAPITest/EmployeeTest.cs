using ASP.NET.NovaPasta;
using ASP.NET.Repositorios;
using System;
using Xunit;

namespace ProjectAPITest
{
    public class EmployeeTest
    {
        [Fact]
        public void NameVerificationTrue()
        {
            //Arrange

            var employee = new EmployeeModel
            {
                name = "gustavo",
                position = "operador",
                email = "gu07ramos@gmail.com"
            };

            var PositionName = new REmployee(null).NameVerification(employee);

            Assert.Equal(employee, PositionName);
        }

        [Fact]
        public void NameVerificationFalse()
        {
            var employee = new EmployeeModel
            {
                name = "gustavo",
                position = "aaaaaa",
                email = "gu07ramos@gmail.com"
            };

            var PositionName = new REmployee(null).NameVerification(employee);

            Assert.Equal(employee, PositionName);
        }
    }
}
