using GarageInventory.Persistence.Abstract.Models.Base;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Models.Tools;

    public class ToolSetModel : BaseItemGroupModel
    {
        public ToolTypes ToolSetType { get; set; }

        public string? ToolSetSpec { get; set; }
    }