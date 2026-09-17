using Dapper;
using GarageInventory.Persistence.Database.Interfaces;

namespace GarageInventory.Persistence.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly string sqlInitializer = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id BLOB PRIMARY KEY,
                Login TEXT NOT NULL UNIQUE,
                Name TEXT NOT NULL,
                Surname TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                UserType INTEGER NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT
            )";

        private readonly IDbConnectionFactory _connectionFactory;

        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task InitializeDatabaseAsync(string connectionString)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            await connection.ExecuteAsync(sqlInitializer);
        }
    }
}
