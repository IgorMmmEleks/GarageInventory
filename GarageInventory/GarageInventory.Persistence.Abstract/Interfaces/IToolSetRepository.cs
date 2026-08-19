namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IToolSetRepository
    {
        Task<int> CreateAsync(ToolSetModel toolSet);
        Task UpdateAsync(ToolSetModel toolSet);
        Task DeleteAsync(int id);
        Task<ToolSetModel?> GetByIdAsync(int id);
    }
