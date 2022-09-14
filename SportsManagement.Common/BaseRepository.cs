using System;
using System.Data;
using Npgsql;

namespace SportsManagement.Common
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }

    public class DbContext : IDbContext
    {
        readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            return connection;
        }

    }
}

