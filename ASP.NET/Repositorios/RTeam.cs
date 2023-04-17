using ASP.NET.Data;
using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Repositorios
{
    public class RTeam : TeamInterface
    {
        private readonly SistemaDB _database;
        public RTeam(SistemaDB TeamSystem)
        {
            _database = TeamSystem;
        }

        public async Task<List<TeamModel>> ViewAllTeams()
        {
            return await _database.Teams.ToListAsync();
        }

        public async Task<TeamModel> SearchTeamID(int id)
        {
            return await _database.Teams.FirstOrDefaultAsync(b => b.Id == id);
        }

        public TeamModel NameVerification(TeamModel Nameverificator)
        {
            if ((Nameverificator.sector.ToLower() == "estoque") || (Nameverificator.sector.ToLower() == "vendas") || (Nameverificator.sector.ToLower() == "financeiro"))
            {
                return Nameverificator;
            }
            else
            {
                throw new Exception("o setor precisa ser definido como: estoque, vendas ou financeiro");
            }
        }

        public TeamModel IDVerification(TeamModel IDverificator)
        {
            if (IDverificator != null)
            {
                IDverificator = IDverificator;
            }

            return IDverificator;
        }

        public async Task<TeamModel> AddTeam(TeamModel equipe)
        {
            NameVerification(equipe);
            _database.Teams.Add(equipe);
            _database.SaveChanges();
            return equipe;
        }

        public async Task<TeamModel> UpdateTeam(TeamModel equipe, int id)
        {
            
            TeamModel equipeID = await SearchTeamID(id);

            NameVerification(equipe);
            IDVerification(equipeID);

            equipeID.Name = equipe.Name;

            _database.Teams.Update(equipeID);
            _database.SaveChanges();

            return equipeID;
        }

        public async Task<bool> DeleteTeam(int id)
        {
            TeamModel equipeID = await SearchTeamID(id);

            IDVerification(equipeID);

            _database.Teams.Remove(equipeID);
            _database.SaveChanges();

            return true;
        }
    }
}