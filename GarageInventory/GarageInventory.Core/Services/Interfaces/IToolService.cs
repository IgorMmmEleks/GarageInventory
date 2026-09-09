using GarageInventory.Core.DTOs.Tools;
using GarageInventory.Core.Results;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Services.Interfaces
{
    public interface IToolService
    {
        Task<OperationResult<int>> GetCountAsync(ToolTypes toolType);
        Task<OperationResult<IEnumerable<ItemToolDto>>> GetAsync(ToolTypes toolType, int skip, int take);
        Task<OperationResult<ItemToolDto>> AddAsync(CreateItemToolDto createItemToolDto);
    }
}
