using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs
{
    public class WheelsSetDto
    {
        public Guid Id { get; set; }

        public Guid? RelatedMotorId { get; set; }
        public string? RelatedMotorName { get; set; }

        public WheelSetTypes WheelSetType { get; set; }
        public string? WheelSetTypeName { get; set; }

        public List<RimDto> Rims { get; set; } = new List<RimDto>();
        public List<TireDto> Tires { get; set; } = new List<TireDto>();
    }
}
