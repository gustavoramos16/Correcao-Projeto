using ASP.NET.Data;
using ASP.NET.NovaPasta;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Repositorios
{
    public class RTeam : TeamInterface<TeamModel>
    {
        private readonly SistemaDB _database;
        public RTeam(SistemaDB TeamSystem)
        {
            _database = TeamSystem;
        }

        public async Task<List<TeamModel>> ViewAll()
        {
            return await _database.Teams.ToListAsync();
        }

        public async Task<TeamModel> SearchID(int id)
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
                return IDverificator;
            }
            else
            {
                throw new Exception("id invalido");
            }

            
        }

        public async Task<TeamModel> Add(TeamModel equipe)
        {
            NameVerification(equipe);
            _database.Teams.Add(equipe);
            _database.SaveChanges();
            return equipe;
        }

        public async Task<TeamModel> Update(TeamModel equipe, int id)
        {
            
            TeamModel equipeID = await SearchID(id);

            NameVerification(equipe);
            IDVerification(equipeID);

            equipeID.Name = equipe.Name;

            _database.Teams.Update(equipeID);
            _database.SaveChanges();

            return equipeID;
        }

        public async Task<bool> Delete(int id)
        {
            TeamModel equipeID = await SearchID(id);

            IDVerification(equipeID);

            _database.Teams.Remove(equipeID);
            _database.SaveChanges();

            return true;
        }
    }
}