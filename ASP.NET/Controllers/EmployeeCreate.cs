using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCreate : ControllerBase
    {
        private readonly EmployeeInterface _remployee;

        public EmployeeCreate(EmployeeInterface repemployee)
        {
            _remployee = repemployee;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeModel>>> SearchForID(int id)
        {
            EmployeeModel employee = await _remployee.SearchEmployeeID(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Register([FromBody] EmployeeModel funcionarioModel)
        {
            EmployeeModel employee = await _remployee.AddEmployee(funcionarioModel);
            return Ok(employee); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeModel>> Update([FromBody] EmployeeModel employeeModel, int id)
        {
            employeeModel.Id = id;
            EmployeeModel employee = await _remployee.UpdateEmployee(employeeModel, id);
            return Ok(employee);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<EmployeeModel>> Delete([FromBody] EmployeeModel employeeModel, int id)
        {
            bool delete = await _remployee.DeleteEmployee(id);
            return Ok(delete);
        }
    }
}
