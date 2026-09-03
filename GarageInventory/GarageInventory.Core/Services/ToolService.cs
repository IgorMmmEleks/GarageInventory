using GarageInventory.Core.DTOs.Items;
using GarageInventory.Core.DTOs.Tools;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Base;
using GarageInventory.Persistence.Abstract.Models.Items;
using GarageInventory.Persistence.Abstract.Models.Tools;
using GarageInventory.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<OperationResult<IEnumerable<ToolItemDto>>> GetAsync(ToolTypes toolType, int skip, int take)
        {
            try
            {
                var items = await _itemRepository.GetItemsByTypeAsync(ItemTypes.Tool, (int)toolType, skip, take);
                
                var toolItemDtos = items.Select(item => new ToolItemDto
                {
                    ItemType = ItemTypes.Tool,
                    ItemSubType = item.ItemSubType,
                    ItemGroupId = item.ItemGroupId,
                    ItemCondition = item.ItemCondition,
                    WasRepaired = item.WasRepaired,
                    ManufactureId = item.ManufactureId,
                    ToolDto = item.ToolDto
                });

                return OperationResult<IEnumerable<ToolItemDto>>.Success(toolItemDtos);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<ToolItemDto>>.Exception(ex);
            }
        }

        public async Task<OperationResult<ToolItemDto>> AddAsync(CreateToolItemDto createToolItemDto)
        {
            try
            {
                var item = new ItemModel
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = (int)ItemTypes.Tool,
                    ItemSubType = createToolItemDto.ItemSubType,
                    ItemCondition = createToolItemDto.ItemCondition,
                    WasRepaired = createToolItemDto.WasRepaired,
                    ManufactureId = createToolItemDto.ManufactureId
                };

        var tool = new ToolModel

                if (createToolItemDto.ItemGroupId != null && createToolItemDto.ItemGroupId > 0)
                {
                    var toolSetId = await _toolSetRepository.Value.Exists(createToolItemDto.ItemGroupId.Value);
                    if (toolSetId != 0)
                        item.ItemGroupId = createToolItemDto.ItemGroupId;
                }


            }
            catch (Exception ex)
            {
                return OperationResult<ToolItemDto>.Exception(ex);
            }

        }
    }
}
