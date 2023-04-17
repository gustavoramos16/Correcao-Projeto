using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamCreate : ControllerBase
    {
        private readonly TeamInterface _rteam;

        public TeamCreate(TeamInterface rteam)
        {
            _rteam = rteam;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TeamModel>>> SearchForID(int id)
        {
            TeamModel team = await _rteam.SearchTeamID(id);
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> Register([FromBody] TeamModel equipeModel)
        {
            TeamModel team = await _rteam.AddTeam(equipeModel);
            return Ok(team);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamModel>> Update([FromBody] TeamModel equipeModel, int id)
        {
            equipeModel.Id = id;
            TeamModel team = await _rteam.UpdateTeam(equipeModel, id);
            return Ok(team);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TeamModel>> Delete([FromBody] TeamModel equipeModel, int id)
        {
            bool del = await _rteam.DeleteTeam(id);
            return Ok(del);
        }
    }
}
