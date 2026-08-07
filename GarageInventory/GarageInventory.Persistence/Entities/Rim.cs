using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Entities
{
    public class Rim : BaseEntity
    {
        public Guid ItemId { get; set; }

        public int RimType { get; set; }

        public int Radius { get; set; }
        public int? Width { get; set; }
        public int? BoltPattern { get; set; }
        public int? Offset { get; set; }
        public int? CenterBore { get; set; }

        public Guid? TireItemId { get; set; }
        public Guid? WheelSetId { get; set; }
    }
}
