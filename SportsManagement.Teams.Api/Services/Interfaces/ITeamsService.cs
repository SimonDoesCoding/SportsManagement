using System;
using SportsManagement.Teams.Api.Models;
namespace SportsManagement.Teams.Api.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<IEnumerable<Team>> Get();
        Task<Team> Get(int id);
        Task ValidateTeamCode(string teamCode, Action<Team> onFound, Action<string> onNotFound);

        Task Create(Team team, Action<Team> onCreated, Action<string> onError);
        Task Update(int id, Team team, Action<Team> onUpdated, Action<string> onError);
        Task Delete(int id, bool isHardDelete, Action onDeleted, Action<string> onError);

        Task<string> GenerateTeamCode(int teamId);
    }
}

