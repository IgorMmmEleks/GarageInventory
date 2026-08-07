namespace GarageInventory.Persistence.Entities
{
    public class ToolSet
    {
        public int Id { get; set; }

        public int ItemGroupId { get; set; }

        public int ToolSetType { get; set; }

        public string? ToolSetSpec { get; set; }
    }
}
