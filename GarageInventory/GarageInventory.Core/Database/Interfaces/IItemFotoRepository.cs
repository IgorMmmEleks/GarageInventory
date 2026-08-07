using GarageInventory.Core.Models.Items;

namespace GarageInventory.Core.Database.Interfaces;

    public interface IItemFotoRepository
    {
        Task<int> CreateAsync(ItemFotoModel itemFoto);
        Task UpdateAsync(ItemFotoModel itemFoto);
        Task DeleteAsync(int id);
        Task<ItemFotoModel?> GetByItemIdAsync(Guid itemId);
    }