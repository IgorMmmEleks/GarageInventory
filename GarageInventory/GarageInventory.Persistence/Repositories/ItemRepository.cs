using GarageInventory.Core.Database.Interfaces;
using GarageInventory.Core.Models.Items;
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

        public Task<IEnumerable<ItemModel>> GetByTypePagineted(ItemTypes itemType, int skip = 0, int take = 10)
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
