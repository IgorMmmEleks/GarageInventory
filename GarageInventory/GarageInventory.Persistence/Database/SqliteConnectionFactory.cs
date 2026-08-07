using System.Data;
using GarageInventory.Persistence.Database.Interfaces;
using Microsoft.Data.Sqlite;

namespace GarageInventory.Persistence.Database
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
