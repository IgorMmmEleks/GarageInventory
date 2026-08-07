using GarageInventory.Core.Models.Tools;

namespace GarageInventory.Core.Database.Interfaces;

    public interface IToolRepository
    {
        Task<int> CreateAsync(ToolModel tool);
        Task UpdateAsync(ToolModel tool);
        Task DeleteAsync(Guid itemId);
        Task<ToolModel?> GetByItemIdAsync(Guid itemId);
    }