using GarageInventory.Persistence.Abstract.Models;

namespace GarageInventory.Persistence.Abstract.Interfaces;

    public interface IUserRepository
    {
        Task<bool> ExistsAsync(string email);

        Task<IEnumerable<UserModel>> GetAllAsync(int skip, int take);

        Task<UserModel?> GetByUserLoginAsync(string login);

        Task<Guid?> CreateAsync(UserModel user);

        Task<bool> UpdateAsync(UserModel user);

        Task<bool> DeleteAsync(Guid id);
    }