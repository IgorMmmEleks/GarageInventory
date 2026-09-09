using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IItemRepository
    {
        Task<int> GetCountAsync(ItemTypes itemType, int itemSubType);
        Task<IEnumerable<ItemModel>> GetByTypePaginetedAsync(ItemTypes itemType, int itemSubType = 0, int skip = 0, int take = 10);
    }