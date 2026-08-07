using GarageInventory.Core.Models.Items;

namespace GarageInventory.Core.Database.Interfaces;

    public interface IItemGroupRepository
    {
        Task<int> CreateAsync(ItemGroupModel itemGroup);
        Task UpdateAsync(ItemGroupModel itemGroup);
        Task DeleteAsync(int id);
        Task<ItemGroupModel?> GetByGroupIdAsync(int groupId);
    }
