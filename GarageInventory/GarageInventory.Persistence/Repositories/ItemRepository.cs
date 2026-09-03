using Dapper;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Persistence.Database.Interfaces;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ItemRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> GetCountAsync(ItemTypes itemType, int itemSubType)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var count = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT() FROM Items WHERE ItemType = @ItemType AND ItemSubType = @ItemSubType",
                    new { ItemType = itemType, ItemSubType = itemSubType });
                return count;
            }
        }

        public Task<int> CreateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemModel>> GetByTypePaginetedAsync(ItemTypes itemType, int itemSubType = 0, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> GetItemsByGroupIdAsync(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }
    }
}
