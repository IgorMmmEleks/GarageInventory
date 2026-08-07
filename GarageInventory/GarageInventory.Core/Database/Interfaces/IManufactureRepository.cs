using GarageInventory.Core.Models;

namespace GarageInventory.Core.Database.Interfaces;
    public interface IManufactureRepository
    {
        Task<int> CreateAsync(ManufactureModel manufacture);
        Task UpdateAsync(ManufactureModel manufacture);
        Task DeleteAsync(int id);
        Task<IEnumerable<ManufactureModel>> GetAllAsync(int skip, int take);
    }