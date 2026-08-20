using GarageInventory.Persistence.Abstract.Models.Base;

namespace GarageInventory.Persistence.Abstract.Models.Items;

    public class ItemModel
    {
        public Guid ItemId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int ItemType { get; set; }
        public int ItemSubType { get; set; }
        public int? ItemGroupId { get; set; }

        public int ItemCondition { get; set; }
        public bool WasRepaired { get; set; }

        public int? ManufactureId { get; set; }
        public string? ManufactureName { get; set; }

        public BaseItemModel? SubModel { get; set; }

        public ItemFotoModel? ItemFoto { get; set; }
    }