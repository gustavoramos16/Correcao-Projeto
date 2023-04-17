using ASP.NET.NovaPasta;

namespace ASP.NET.Repositorios.Interfaces
{
    public interface TeamInterface
    {
        Task<List<TeamModel>> ViewAllTeams();

        Task<TeamModel> SearchTeamID(int id);

        Task<TeamModel> AddTeam(TeamModel team);

        Task<TeamModel> UpdateTeam(TeamModel team, int id);

        Task<bool> DeleteTeam(int id);

    }
}
