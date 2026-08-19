namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IItemRepository
    {
        Task<ItemModel?> GetByIdAsync(int id);
        Task<IEnumerable<ItemModel>> GetByTypePagineted(ItemTypes itemType, int skip = 0, int take = 10);
        Task<IEnumerable<ItemModel>> GetAllAsync();
        Task<int> CreateAsync(ItemModel item);
        Task UpdateAsync(ItemModel item);
        Task DeleteAsync(int id);

        Task<IEnumerable<ItemModel>> GetItemsByGroupIdAsync(int groupId);
    }