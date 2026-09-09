using Dapper;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Database.Interfaces;

namespace GarageInventory.Persistence.Repositories
{
    public class ToolSetRepository : IToolSetRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ToolSetRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> ExistsAsync(int toolSetId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<bool>(
                    """
                    SELECT CAST(
                        CASE WHEN EXISTS (
                            SELECT 1
                            FROM ToolSets
                            WHERE ToolSetId = @ToolSetId
                        )
                        THEN 1
                        ELSE 0
                        END AS bit)
                    """,
                    new { ToolSetId = toolSetId });
            }
        }
    }
}
