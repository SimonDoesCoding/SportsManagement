using System;
using SportsManagement.Teams.Api.Models;
using SportsManagement.Teams.Api.Services.Interfaces;

namespace SportsManagement.Teams.Api.Services
{
    public class TeamsService : ITeamsService
    {

        public TeamsService()
        {
        }

        public Task Create(Team team, Action<Team> onCreated, Action<string> onError)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, bool isHardDelete, Action onDeleted, Action<string> onError)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateTeamCode(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Team> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Team team, Action<Team> onUpdated, Action<string> onError)
        {
            throw new NotImplementedException();
        }

        public Task ValidateTeamCode(string teamCode, Action<Team> onFound, Action<string> onNotFound)
        {
            throw new NotImplementedException();
        }
    }
}

