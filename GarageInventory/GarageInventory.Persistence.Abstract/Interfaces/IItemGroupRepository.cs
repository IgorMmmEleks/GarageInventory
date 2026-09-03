using GarageInventory.Persistence.Abstract.Models.Items;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IItemGroupRepository
    {
        Task<int> CreateAsync(ItemGroupModel itemGroup);
        Task UpdateAsync(ItemGroupModel itemGroup);
        Task DeleteAsync(int id);
        Task<ItemGroupModel?> GetByGroupIdAsync(int groupId);
    }
