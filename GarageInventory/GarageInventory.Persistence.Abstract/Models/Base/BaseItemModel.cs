namespace GarageInventory.Persistence.Abstract.Models.Base;

    public abstract class BaseItemModel
    {
        public Guid ItemId { get; set; }
        public string? Description { get; set; }
    }