using GarageInventory.Persistence.Abstract.Models.Tools;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IToolSetRepository
    {
        Task<bool> ExistsAsync(int toolSetId);
    }
