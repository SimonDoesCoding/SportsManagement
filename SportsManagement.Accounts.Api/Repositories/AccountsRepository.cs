using System;
using SportsManagement.Accounts.Api.DTOs;
using SportsManagement.Accounts.Api.Repositories.Interfaces;
using SportReflections.Common.Interfaces;
using Dapper;

namespace SportsManagement.Accounts.Api.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        readonly string _connectionString;
        readonly IDbContext _dbContext;

            public AccountsRepository(IConfiguration config, IDbContext dbContext)
        {
            _connectionString = config.GetConnectionString("PostgresConnectionString");
            _dbContext = dbContext;

        }

        public async Task Create(AccountDTO account)
        {
            var sql = "insert into Accounts values (@FirstName, @LastName, @EmailAddress, @Password, @PasswordSalt, @CreatedDate, @IsDeleted)";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(sql, account);
        }

        public async Task<IEnumerable<AccountDTO>> Get()
        {
            var sql = "select * from Accounts where IsDeleted = 0";

            using var connection = _dbContext.CreateConnection(_connectionString);
            var accounts = await connection.QueryAsync<AccountDTO>(sql);

            return accounts;
        }

        public async Task<AccountDTO> Get(int id)
        {
            var sql = "select * from Accounts where Id = @Id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            var account = await connection.QuerySingleAsync<AccountDTO>(sql, new { Id = id });

            return account;
        }

        public async Task HardDelete(int id)
        {
            var sql = "delete from Accounts where Id = @Id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task SoftDelete(int id)
        {
            var sql = "update Accounts set IsDeleted = 0 where Id = @Id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.QueryAsync(sql, new { Id = id });
        }

        public async Task Update(int id, AccountDTO updatedAccount)
        {
            var sql = "update Accounts set FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress where Id = @Id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(sql, updatedAccount);
        }

    }
}

