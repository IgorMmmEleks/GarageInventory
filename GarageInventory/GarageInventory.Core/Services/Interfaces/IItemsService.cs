using GarageInventory.Core.DTOs.Items;
using GarageInventory.Core.Results;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Services.Interfaces
{
    public interface IItemsService
    {
        Task<OperationResult<int>> GetCountAsync(ItemTypes itemType, int itemSubType, int skip, int take);
        Task<OperationResult<IEnumerable<ItemDto>>> GetAsync(ItemTypes itemType, int itemSubType, int skip, int take);
    }
}
