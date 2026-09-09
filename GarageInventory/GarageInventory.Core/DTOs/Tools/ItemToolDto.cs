using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Tools
{
    public class ItemToolDto
    {
        public ItemTypes ItemType { get; set; } = ItemTypes.Tool;
        public int ItemSubType { get; set; }

        public int? ItemGroupId { get; set; }

        public int ItemCondition { get; set; }
        public bool WasRepaired { get; set; }

        public int? ManufactureId { get; set; }

        public ToolDto? ToolDto { get; set; }
    }
}
