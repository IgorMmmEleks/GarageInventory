namespace GarageInventory.Persistence.Abstract.Models;

    public class BaseItemModel
    {
        public Guid ItemId { get; set; }
        public string? Description { get; set; }
    }