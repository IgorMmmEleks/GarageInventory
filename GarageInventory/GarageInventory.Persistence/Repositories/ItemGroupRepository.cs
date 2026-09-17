using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory.Persistence.Repositories
{
    public class ItemGroupRepository : IItemGroupRepository
    {
        public Task<int> CreateAsync(ItemGroupModel itemGroup)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemGroupModel?> GetByGroupIdAsync(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemGroupModel itemGroup)
        {
            throw new NotImplementedException();
        }
    }
}
