using GarageInventory.Core.Models.Tools;

namespace GarageInventory.Core.Database.Interfaces;

public interface IToolSetRepository
{
    Task<int> CreateAsync(ToolSetModel toolSet);
    Task UpdateAsync(ToolSetModel toolSet);
    Task DeleteAsync(int id);
    Task<ToolSetModel?> GetByIdAsync(int id);
}
