using GarageInventory.Persistence.Abstract.Models;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IManufactureRepository
    {
        Task<int> CreateAsync(ManufactureModel manufacture);
        Task UpdateAsync(ManufactureModel manufacture);
        Task DeleteAsync(int id);
        Task<IEnumerable<ManufactureModel>> GetAllAsync(int skip, int take);
    }