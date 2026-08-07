using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Wheels
{
    public class RimDto
    {
        public Guid Id { get; set; }
        public RimTypes RimType { get; set; }
        public string? RimTypeName { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ModelName { get; set; }
        public ItemConditionTypes Condition { get; set; }
        public string? ConditionName { get; set; }
        public bool WasRepaired { get; set; }

        public int Radius { get; set; }
        public int? Width { get; set; }
        public int? BoltPattern { get; set; }
        public int? Offset { get; set; }
        public int? CenterBore { get; set; }
        public bool HasTire { get; set; }
        public Guid? TireId { get; set; }

        public Guid? WheelSetId { get; set; }

        public List<Guid?> FotosIds { get; set; } = new List<Guid?>();
        public string? Description { get; set; }
    }
}
