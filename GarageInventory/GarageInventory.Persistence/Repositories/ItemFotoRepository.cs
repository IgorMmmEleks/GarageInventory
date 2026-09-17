using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Items;

namespace GarageInventory.Persistence.Repositories
{
    public class ItemFotoRepository : IItemFotoRepository
    {
        public Task<int> CreateAsync(ItemFotoModel itemFoto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemFotoModel?> GetByItemIdAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemFotoModel itemFoto)
        {
            throw new NotImplementedException();
        }
    }
}
