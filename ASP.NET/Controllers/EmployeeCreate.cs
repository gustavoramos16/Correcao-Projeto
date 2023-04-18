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
        private readonly EmployeeInterface<TeamModel> _remployee;

        public EmployeeCreate(EmployeeInterface<TeamModel> repemployee)
        {
            _remployee = repemployee;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeModel>>> SearchForID(int id)
        {
            EmployeeModel employee = await _remployee.SearchID(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> Register([FromBody] EmployeeModel funcionarioModel)
        {
            EmployeeModel employee = await _remployee.Add(funcionarioModel);
            return Ok(employee); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeModel>> Update([FromBody] EmployeeModel employeeModel, int id)
        {
            employeeModel.Id = id;
            EmployeeModel employee = await _remployee.Update(employeeModel, id);
            return Ok(employee);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<EmployeeModel>> Delete([FromBody] EmployeeModel employeeModel, int id)
        {
            bool delete = await _remployee.Delete(id);
            return Ok(delete);
        }
    }
}
