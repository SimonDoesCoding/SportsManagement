using System;
using SportsManagement.Teams.Api.DTOs;

namespace SportsManagement.Teams.Api.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        Task<IEnumerable<TeamDTO>> Get();
        Task<TeamDTO> Get(int id);
        Task ValidateTeamCode(string teamCode, Action<TeamDTO> onValidTeamCode, Action<string> onInvalidTeamCode);

        Task Create(TeamDTO team, Action onCreated, Action<string> onError);
        Task Update(int id, TeamDTO updatedTeam, Action onUpdated, Action<string> onError);
        Task HardDelete(int id, Action onDeleted, Action<string> onError);
        Task SoftDelete(int id, Action onDeleted, Action<string> onError);
    }
}

