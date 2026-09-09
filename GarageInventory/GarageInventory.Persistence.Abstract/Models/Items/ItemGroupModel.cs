using GarageInventory.Persistence.Abstract.Models.Base;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Models.Items;

    public class ItemGroupModel
    {
        public int Id { get; set; }

        public string? GroupName { get; set; }

        public ItemTypes ItemGroupType { get; set; }

        public BaseItemGroupModel SubGroupModel { get; set; }

        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
    }
