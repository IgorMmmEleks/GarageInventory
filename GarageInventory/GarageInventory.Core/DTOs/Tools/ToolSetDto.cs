using GarageInventory.Core.DTOs.Base;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Tools
{
    public class ToolSetDto : BaseItemGroupDto
    {
        public ToolTypes ToolSetType { get; set; }

        public string? ToolSetSpec { get; set; }
    }
}
