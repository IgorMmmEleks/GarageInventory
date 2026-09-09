using Dapper;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Persistence.Abstract.Models.Tools;
using GarageInventory.Persistence.Database.Interfaces;

namespace GarageInventory.Persistence.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ToolRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AddAsync(ItemModel toolItem)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsync(
                    insertItemSql,
                    toolItem,
                    transaction);

                await connection.ExecuteAsync(
                    insertToolSql,
                    toolItem.SubModel,
                    transaction);

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Task<IEnumerable<ItemModel>> GetByTypePaginetedAsync(int toolType, int skip, int take)
        {
            using var connection = _connectionFactory.CreateConnection();

            return connection.QueryAsync<ItemModel, ToolModel, ItemModel>(
                getByTypePaginatedSql,
                (item, tool) =>
                {
                    item.SubModel = tool;
                    return item;
                },
                new { ToolType = toolType, Skip = skip, Take = take });
        }


        #region SQL's

        private const string getByTypePaginatedSql = @"
            SELECT i.*, t.*
            FROM Items i
            INNER JOIN Tools t ON i.Id = t.ItemId
            WHERE i.ItemType = 1
                AND t.ToolType = @ToolType
            ORDER BY i.CreatedAt, i.UpdatedAt
            OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

        private const string insertItemSql = @"
            INSERT INTO Items (Id, ItemType, ItemSubType, ItemGroupId, ItemCondition, WasRepaired, ManufactureId, CreatedAt)
            VALUES (@Id, @ItemType, @ItemSubType, @ItemGroupId, @ItemCondition, @WasRepaired, @ManufactureId, @CreatedAt); ";

        private const string insertToolSql = @"
            INSERT INTO Tools (ItemId, Description, ToolType, ToolStandart, ToolName, ToolSpec)
            VALUES (@ItemId, @Description, @ToolType, @ToolStandart, @ToolName, @ToolSpec);";

        #endregion
    }
}