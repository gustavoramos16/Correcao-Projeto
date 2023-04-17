using ASP.NET.Data;
using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Repositorios
{
    public class REmployee : EmployeeInterface
    {
        private readonly SistemaDB _database;

        public REmployee(SistemaDB EmployeeSystem)
        {
            _database = EmployeeSystem;
        }

        public async Task<List<EmployeeModel>> ViewAllEmployee()
        {
            return await _database.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> SearchEmployeeID(int id)
        {
            return await _database.Employees.FirstOrDefaultAsync(b => b.Id == id);
        }

        public EmployeeModel NameVerification(EmployeeModel nameverificator)
        {

            if (nameverificator.position.ToLower() == "gerente" || nameverificator.position.ToLower() == "operador")
            {
                if (nameverificator.position.ToLower() != "gerente")
                {
                    return nameverificator;
                }
                else
                {
                    if (nameverificator.email == "")
                    {
                        throw new Exception("O campo email é obrigatório para gerentes");
                    }
                    else
                    {
                        return nameverificator;
                    }
                }
            }
            else
            {
                throw new Exception("O cargo deve ser definido como: gerente ou operador");
            }

        }

        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            NameVerification(employee);
            _database.Employees.Add(employee);
            _database.SaveChanges();
            return employee;
        }

        public async Task<EmployeeModel> UpdateEmployee(EmployeeModel employee, int id)
        {
            EmployeeModel EmployeeID = await SearchEmployeeID(id);

            NameVerification(EmployeeID);

            if (EmployeeID == null)
            {
                throw new Exception($"O ID: {id} não foi encontrado");
            }

            EmployeeID.name = employee.name;
            EmployeeID.email = employee.email;
            EmployeeID.TeamReference = employee.TeamReference;

            _database.SaveChanges();

            return EmployeeID;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            EmployeeModel funcionarioID = await SearchEmployeeID(id);

            if (funcionarioID == null)
            {
                throw new Exception($"O ID: {id} relacionado com funcionario não foi encontrado");

            }

            _database.Employees.Remove(funcionarioID);
            _database.SaveChanges();

            return true;

        }
    }
}


