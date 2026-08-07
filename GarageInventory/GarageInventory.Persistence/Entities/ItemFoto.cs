namespace GarageInventory.Persistence.Entities
{
    public class ItemFoto : BaseEntity
    {
        public int Id { get; set; }
        public string? RelativePath { get; set; }
    }
}