using GarageInventory.Core.Database.Interfaces;
using GarageInventory.Core.Models;
using GarageInventory.Persistence.Database.Interfaces;

namespace GarageInventory.Persistence.Repositories
{
    public class ManufactureRepository : IManufactureRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ManufactureRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }

        public Task<int> CreateAsync(ManufactureModel manufacture)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManufactureModel>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ManufactureModel manufacture)
        {
            throw new NotImplementedException();
        }
    }
}
