namespace GarageInventory.Persistence.Entities
{
    public class Clothes : BaseEntity
    {
        public Guid ItemId { get; set; }

        public int ClothesType { get; set; }
    }
}
