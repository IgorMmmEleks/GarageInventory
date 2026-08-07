using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Wheels
{
    public class TireDto
    {
        public Guid Id { get; set; }
        public TireTypes TireType { get; set; }
        public string? TireTypeName { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ModelName { get; set; }
        public ItemConditionTypes Condition { get; set; }
        public string? ConditionName { get; set; }
        public bool WasRepaired { get; set; }

        public DateOnly? ManufacturedAt { get; set; }
        public DateOnly? InUseFrom { get; set; }

        public int Radius { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsOnRim { get; set; }
        public Guid? RimId { get; set; }

        public Guid? WheelSetId { get; set; }

        public List<Guid?> FotosIds { get; set; } = new List<Guid?>();
        public string? Description { get; set; }
    }
}
