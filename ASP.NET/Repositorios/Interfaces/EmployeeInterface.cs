using ASP.NET.NovaPasta;

namespace ASP.NET.Repositorios.Interfaces
{
    public interface EmployeeInterface
    {
        Task<List<EmployeeModel>> ViewAllEmployee();

        Task<EmployeeModel> SearchEmployeeID(int id);

        Task<EmployeeModel> AddEmployee(EmployeeModel funcionario);

        Task<EmployeeModel> UpdateEmployee(EmployeeModel funcionario, int id);

        Task<bool> DeleteEmployee(int id);
    }
}
