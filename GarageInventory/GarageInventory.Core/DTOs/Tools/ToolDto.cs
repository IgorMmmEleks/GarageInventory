using GarageInventory.Core.DTOs.Base;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Tools
{
    public class ToolDto : BaseItemDto
    {
        public ToolTypes ToolType { get; set; }

        public ToolStandarts ToolStandart { get; set; }

        public string? ToolName { get; set; }

        public string? ToolSpec { get; set; }
    }
}