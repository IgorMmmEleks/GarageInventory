using GarageInventory.Core.Models.Items;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Models.Tools
{
    public class ToolSetModel : BaseItemGroupModel
    {
        public ToolTypes ToolSetType { get; set; }

        public string? ToolSetSpec { get; set; }
    }
}
