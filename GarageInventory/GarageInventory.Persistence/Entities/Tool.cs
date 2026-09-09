namespace GarageInventory.Persistence.Entities
{
    public class Tool : BaseEntity
    {
        public int ToolType { get; set; }

        public int ToolStandart { get; set; }

        public string? ToolName { get; set; }

        public string? ToolSpec { get; set; }
    }
}
