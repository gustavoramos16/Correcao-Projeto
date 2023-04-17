using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsList: ControllerBase
    {
        private readonly TeamInterface _equiperep;

        public TeamsList(TeamInterface equiperep)
        {
            _equiperep = equiperep;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamModel>>> ExibirEquipes()
        {
            List<TeamModel> equipes = await _equiperep.ViewAllTeams();
            return Ok(equipes);
        }
    }
}
