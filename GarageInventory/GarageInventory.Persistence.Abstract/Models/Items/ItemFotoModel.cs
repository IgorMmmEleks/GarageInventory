using GarageInventory.Persistence.Abstract.Models.Base;

namespace GarageInventory.Persistence.Abstract.Models.Items;

    public class ItemFotoModel : BaseItemModel
    {
        public int Id { get; set; }
        public string? RelativePath { get; set; }
    }
