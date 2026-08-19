using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Models;

    public class ToolSetModel : BaseItemGroupModel
    {
        public ToolTypes ToolSetType { get; set; }

        public string? ToolSetSpec { get; set; }
    }