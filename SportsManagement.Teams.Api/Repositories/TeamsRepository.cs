using System;
using Dapper;
using SportsManagement.Common;
using SportsManagement.Teams.Api.DTOs;
using SportsManagement.Teams.Api.Repositories.Interfaces;

namespace SportsManagement.Teams.Api.Repositories
{
    public class TeamsRepository :ITeamsRepository
    {
        readonly IDbContext _dbContext;

        public TeamsRepository(IConfiguration config, IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TeamDTO team, Action onCreated, Action<string> onError)
        {
            var sql = "insert into Teams values (@Name, @TeamCode)";

            using var connection = _dbContext.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, team);

            if(rowsAffected == 0)
            {
                onError($"Failed to create team: {team.Name}");
                return;
            }

            onCreated();
        }

        public async Task<IEnumerable<TeamDTO>> Get()
        {
            var sql = "select * from Teams where IsDeleted = 0";

            using var connection = _dbContext.CreateConnection();
            var teams = await connection.QueryAsync<TeamDTO>(sql);

            return teams;
        }

        public async Task<TeamDTO> Get(int id)
        {
            var sql = "select * from Teams where Id = @Id";

            using var connection = _dbContext.CreateConnection();
            var team = await connection.QuerySingleAsync<TeamDTO>(sql, new { Id = id });

            return team;
        }

        public async Task HardDelete(int id, Action onDeleted, Action<string> onError)
        {
            var sql = "delete from Teams where Id = @Id";
            await Delete(id, sql, onDeleted, onError);
        }

        public async Task SoftDelete(int id, Action onDeleted, Action<string> onError)
        {
            var sql = "update Teams set IsDeleted = 1 where Id = @Id";
            await Delete(id, sql, onDeleted, onError);
        }

        private async Task Delete(int id, string sql, Action onDeleted, Action<string> onError)
        {
            using var connection = _dbContext.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });

            if(rowsAffected == 0)
            {
                onError($"Failed to delete id: {id}");
                return;
            }

            onDeleted();
        }

        public async Task Update(int id, TeamDTO updatedTeam, Action onUpdated, Action<string> onError)
        {
            var sql = "update Teams set Name = @Name, TeamCode = @TeamCode where Id = @Id";

            using var connection = _dbContext.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, updatedTeam);

            if(rowsAffected == 0)
            {
                onError($"Failed to update Team: {id}");
                return;
            }

            onUpdated();
        }

        public async Task ValidateTeamCode(string teamCode, Action<TeamDTO> onValidTeamCode, Action<string> onInvalidTeamCode)
        {
            var sql = "select * from Teams where TeamCode = @TeamCode";

            using var connection = _dbContext.CreateConnection();
            var team = await connection.QuerySingleOrDefaultAsync<TeamDTO>(sql, new { TeamCode = teamCode });

            if(team == null)
            {
                onInvalidTeamCode($"Could not find a team with teamcode: {teamCode}");
                return;
            }

            onValidTeamCode(team);
        }
    }
}

