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
        private readonly TeamInterface<TeamModel> _rteam;

        public TeamCreate(TeamInterface<TeamModel> rteam)
        {
            _rteam = rteam;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TeamModel>>> SearchForID(int id)
        {
            TeamModel team = await _rteam.SearchID(id);
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> Register([FromBody] TeamModel equipeModel)
        {
            TeamModel team = await _rteam.Add(equipeModel);
            return Ok(team);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamModel>> Update([FromBody] TeamModel equipeModel, int id)
        {
            equipeModel.Id = id;
            TeamModel team = await _rteam.Update(equipeModel, id);
            return Ok(team);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TeamModel>> Delete([FromBody] TeamModel equipeModel, int id)
        {
            bool del = await _rteam.Delete(id);
            return Ok(del);
        }
    }
}
