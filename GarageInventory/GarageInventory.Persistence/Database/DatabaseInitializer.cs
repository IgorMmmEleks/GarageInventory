using Dapper;
using GarageInventory.Persistence.Database.Interfaces;
using Microsoft.Data.Sqlite;

namespace GarageInventory.Persistence.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {

        //VERIFY AND UPDATE !!!
        private readonly string sqlInitializer = @"
            CREATE TABLE IF NOT EXISTS Items (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );
            CREATE TABLE IF NOT EXISTS Products (
                ItemId INTEGER PRIMARY KEY,
                Sku TEXT NOT NULL,
                Price REAL NOT NULL,
                FOREIGN KEY(ItemId) REFERENCES Items(Id)
            );";

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
