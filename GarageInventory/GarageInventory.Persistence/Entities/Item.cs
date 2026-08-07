namespace GarageInventory.Persistence.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        //This is type of items. Tool, Wheel, Clothing, MotorParts or other. 
        public int ItemType { get; set; }

        //This is subtype of items. If ItemType is Wheel, ItemSubType can be Rim or Tire.
        public int ItemSubType { get; set; }

        //This is group of items. If ItemType is Tool, ItemGroup can be same toolset which gathers diff items.
        //If ItemType is Wheel, ItemGroup can be wheelset which gathers rims and tires.
        public int? ItemGroupId { get; set; }

        public int ItemCondition { get; set; }

        public bool WasRepaired { get; set; }

        public int? ManufactureId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
