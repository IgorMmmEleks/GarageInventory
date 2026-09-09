using GarageInventory.Persistence.Abstract.Models.Items;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IToolRepository
    {
        Task<bool> AddAsync(ItemModel toolItem);

        Task<IEnumerable<ItemModel>> GetByTypePaginetedAsync(int toolType, int skip, int take);
}