namespace GarageInventory.Persistence.Entities
{
    public class BaseEntity
    {
        public Guid ItemId { get; set; }

        public string? Description { get; set; }
    }
}