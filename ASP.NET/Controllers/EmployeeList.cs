using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesList : ControllerBase
    {
        private readonly EmployeeInterface<EmployeeModel> _funcionariorep;

        public EmployeesList(EmployeeInterface<EmployeeModel> funcionariorep)
        {
            _funcionariorep = funcionariorep;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> ExibirFuncionarios()
        {
            List<EmployeeModel> funcionarios = await _funcionariorep.ViewAll();
            return Ok(funcionarios);
        }
    }
}
