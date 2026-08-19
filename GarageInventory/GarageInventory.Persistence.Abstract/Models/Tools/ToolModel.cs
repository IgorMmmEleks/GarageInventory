namespace GarageInventory.Persistence.Abstract.Models;

    public class ToolModel : BaseItemModel
    {
        public int ToolType { get; set; }

        public int ToolStandart { get; set; }

        public string? ToolName { get; set; }

        public string? ToolSpec { get; set; }
    }
