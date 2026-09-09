using GarageInventory.Core.DTOs.Tools;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Persistence.Abstract.Models.Tools;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Services
{
    public class ToolService : IToolService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IToolRepository _toolRepository;
        private readonly Lazy<IToolSetRepository> _toolSetRepository;

        public ToolService(
            IItemRepository itemRepository, 
            IToolRepository toolRepository, 
            Lazy<IToolSetRepository> toolSetRepository)
        {
            _itemRepository = itemRepository;
            _toolRepository = toolRepository;
            _toolSetRepository = toolSetRepository;
        }

        public async Task<OperationResult<int>> GetCountAsync(ToolTypes toolType)
        {
            try
            {
                var itemsCount = await _itemRepository.GetCountAsync(ItemTypes.Tool, (int)toolType);

                return OperationResult<int>.Success(itemsCount);
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Exception(ex);
            }
        }

        public async Task<OperationResult<IEnumerable<ItemToolDto>>> GetAsync(ToolTypes toolType, int skip, int take)
        {
            try
            {
                var toolItems = await _toolRepository.GetByTypePaginetedAsync((int)toolType, skip, take);
                
                var toolItemDtos = toolItems.Select(item => new ItemToolDto
                {
                    ItemType = ItemTypes.Tool,
                    ItemSubType = item.ItemSubType,
                    ItemGroupId = item.ItemGroupId,
                    ItemCondition = item.ItemCondition,
                    WasRepaired = item.WasRepaired,
                    ManufactureId = item.ManufactureId,
                    ToolDto = item.SubModel is ToolModel toolModel ? new ToolDto
                    {
                        Description = toolModel.Description,
                        ToolType = (ToolTypes)toolModel.ToolType,
                        ToolStandart = (ToolStandarts)toolModel.ToolStandart,
                        ToolName = toolModel.ToolName,
                        ToolSpec = toolModel.ToolSpec
                    } : null
                });

                return OperationResult<IEnumerable<ItemToolDto>>.Success(toolItemDtos);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<ItemToolDto>>.Exception(ex);
            }
        }

        public async Task<OperationResult<ItemToolDto>> AddAsync(CreateItemToolDto createItemToolDto)
        {
            try
            {
                var toolItem = new ItemModel
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = (int)ItemTypes.Tool,
                    ItemSubType = createItemToolDto.ItemSubType,
                    ItemCondition = createItemToolDto.ItemCondition,
                    WasRepaired = createItemToolDto.WasRepaired,
                    ManufactureId = createItemToolDto.ManufactureId,
                    CreatedAt = DateTime.UtcNow,
                };

                toolItem.SubModel = new ToolModel 
                { 
                    ItemId = toolItem.ItemId,
                    Description = createItemToolDto.ToolDto.Description,
                    ToolType = (int)createItemToolDto.ToolDto.ToolType,
                    ToolStandart = (int)createItemToolDto.ToolDto.ToolStandart,
                    ToolName = createItemToolDto.ToolDto.ToolName,
                    ToolSpec = createItemToolDto.ToolDto.ToolSpec,
                };

                if (createItemToolDto.ItemGroupId != null && createItemToolDto.ItemGroupId > 0)
                {
                    if (await _toolSetRepository.Value.ExistsAsync(createItemToolDto.ItemGroupId.Value))
                        toolItem.ItemGroupId = createItemToolDto.ItemGroupId;
                }

                bool result = await _toolRepository.AddAsync(toolItem);

                if(result)
                {
                    var itemToolDto = new ItemToolDto
                    {
                        ItemType = ItemTypes.Tool,
                        ItemSubType = toolItem.ItemSubType,
                        ItemGroupId = toolItem.ItemGroupId,
                        ItemCondition = toolItem.ItemCondition,
                        WasRepaired = toolItem.WasRepaired,
                        ManufactureId = toolItem.ManufactureId,
                        ToolDto = new ToolDto
                        {
                            Description = toolItem.SubModel.Description,
                            ToolType = (ToolTypes)((ToolModel)toolItem.SubModel).ToolType,
                            ToolStandart = (ToolStandarts)((ToolModel)toolItem.SubModel).ToolStandart,
                            ToolName = ((ToolModel)toolItem.SubModel).ToolName,
                            ToolSpec = ((ToolModel)toolItem.SubModel).ToolSpec
                        }
                    };

                    return OperationResult<ItemToolDto>.Success(itemToolDto);
                }
                else
                {
                    return OperationResult<ItemToolDto>.Failure(OperationResultErrors.Failed);
                }

            }
            catch (Exception ex)
            {
                return OperationResult<ItemToolDto>.Exception(ex);
            }
        }
    }
}
