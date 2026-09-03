using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IItemRepository
    {
        Task<int> GetCountAsync(ItemTypes itemType, int itemSubType);
        Task<ItemModel?> GetByIdAsync(int id);
        Task<IEnumerable<ItemModel>> GetByTypePaginetedAsync(ItemTypes itemType, int itemSubType = 0, int skip = 0, int take = 10);
        Task<IEnumerable<ItemModel>> GetAllAsync();
        Task<int> CreateAsync(ItemModel item);
        Task UpdateAsync(ItemModel item);
        Task DeleteAsync(int id);

        Task<IEnumerable<ItemModel>> GetItemsByGroupIdAsync(int groupId);
    }