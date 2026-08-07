using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory.Persistence.Entities
{
    public class Tire : BaseEntity
    {
        public Guid ItemId { get; set; }

        public int TireType { get; set; }

        public int Radius { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public Guid? RimItemId { get; set; }
        public Guid? WheelSetId { get; set; }
    }
}
