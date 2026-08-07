using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Models.Items
{
    public class ItemGroupModel
    {
        public int Id { get; set; }

        public string? GroupName { get; set; }

        public ItemTypes ItemGroupType { get; set; }

        public BaseItemGroupModel SubGroupModel { get; set; } = new BaseItemGroupModel();

        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
    }
}
