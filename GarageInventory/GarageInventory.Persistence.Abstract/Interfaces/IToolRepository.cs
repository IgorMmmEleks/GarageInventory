namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IToolRepository
    {
        Task<int> CreateAsync(ToolModel tool);
        Task UpdateAsync(ToolModel tool);
        Task DeleteAsync(Guid itemId);
        Task<ToolModel?> GetByItemIdAsync(Guid itemId);
    }