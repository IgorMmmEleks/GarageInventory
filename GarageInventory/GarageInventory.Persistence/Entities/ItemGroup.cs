using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Entities
{
    public class ItemGroup
    {
        public int Id { get; set; }

        public string? GroupName { get; set; }

        public ItemTypes ItemGroupType { get; set; }
    }
}
