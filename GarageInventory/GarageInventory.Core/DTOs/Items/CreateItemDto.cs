using GarageInventory.Core.DTOs.Base;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Items
{
    public class CreateItemDto
    {
        public ItemTypes ItemType { get; set; }
        public int ItemSubType { get; set; }

        //An Item can be added to some group on Create acction.
        public int? ItemGroupId { get; set; }

        public int ItemCondition { get; set; }
        public bool WasRepaired { get; set; }

        public int? ManufactureId { get; set; }

        public BaseItemDto? SubModel { get; set; }
    }
}
