using GarageInventory.Core.DTOs.Items;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Base;
using GarageInventory.Shared.Enums;


namespace GarageInventory.Core.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemRepository _itemRepository;
        private readonly Lazy<IItemFotoRepository> _itemFotoRepository;
        private readonly Lazy<IItemGroupRepository> _itemGroupRepository;
        private readonly Lazy<IManufactureRepository> _manufactureRepository;
        private readonly Lazy<IToolRepository> _toolRepository;
        private readonly Lazy<IToolSetRepository> _toolSetRepository;

        public ItemsService(
            IItemRepository itemRepository,
            Lazy<IItemFotoRepository> itemFotoRepository,
            Lazy<IItemGroupRepository> itemGroupRepository,
            Lazy<IManufactureRepository> manufactureRepository,
            Lazy<IToolRepository> toolRepository,
            Lazy<IToolSetRepository> toolSetRepository)
        {
            _itemRepository = itemRepository;
            _itemFotoRepository = itemFotoRepository;
            _itemGroupRepository = itemGroupRepository;
            _manufactureRepository = manufactureRepository;
            _toolRepository = toolRepository;
            _toolSetRepository = toolSetRepository;
        }

        public async Task<OperationResult<IEnumerable<ItemDto>>> GetAsync(ItemTypes itemType, int itemSubType, int skip, int take)
        {
            try
            {
                var items = await _itemRepository.GetByTypePaginetedAsync(itemType, itemSubType, skip, take);
                
                if (items == null)
                    return OperationResult<IEnumerable<ItemDto>>.Failure(OperationResultErrors.Failed);

                var subItems = await GetSubItems(items.Select(i => i.ItemId).ToList(), itemType, itemSubType);

                if (subItems == null)
                    return OperationResult<IEnumerable<ItemDto>>.Failure(OperationResultErrors.Failed);

                //return OperationResult<IEnumerable<ItemDto>>.Success(_mapper.Map<IEnumerable<ItemModel>, IEnumerable<ItemDto>>(items));
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<ItemDto>>.Exception(ex);
            }
        }

        public Task<OperationResult<int>> GetCountAsync(ItemTypes itemType, int itemSubType, int skip, int take)
        {
            throw new NotImplementedException();
        }


        #region Private

        public async Task<List<BaseItemModel>> GetSubItems(List<Guid> itemIds, ItemTypes itemType, int itemSubType)
        {
            itemType switch
            {
                ItemTypes.Tool => await _toolRepository.Value.GetByItemIdsAsync(itemIds),
                ItemTypes.Wheel => throw new NotImplementedException(),
                ItemTypes.Clothing => throw new NotImplementedException(),
                ItemTypes.MotorParts => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }
        #endregion
    }
}
