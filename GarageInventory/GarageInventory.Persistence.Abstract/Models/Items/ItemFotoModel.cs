namespace GarageInventory.Persistence.Abstract.Models;

    public class ItemFotoModel : BaseItemModel
    {
        public int Id { get; set; }
        public string? RelativePath { get; set; }
    }
