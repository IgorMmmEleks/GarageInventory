using GarageInventory.Core.DTOs.Tools;
using GarageInventory.Shared.Enums;
using System.Text.Json.Serialization;

namespace GarageInventory.Core.DTOs.Base
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "itemType")]
    [JsonDerivedType(typeof(ToolDto), "Tool")]
    //[JsonDerivedType(typeof(), "Wheel")]
    //[JsonDerivedType(typeof(), "Clothing")]
    //[JsonDerivedType(typeof(), "MotorParts")]
    public abstract class BaseItemDto
    {
        public ItemTypes ItemType { get; set; }
        public Guid? ItemId { get; set; }
        public string? Description { get; set; }
    }
}
