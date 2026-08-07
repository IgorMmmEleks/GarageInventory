using GarageInventory.Core.Models.Users;

namespace GarageInventory.Core.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(string email);
        Task<Guid?> CreateAsync(UserModel user);
        Task<bool> UpdateAsync(UserModel user);
        Task<bool> DeleteAsync(Guid id);
        Task<UserModel?> GetByUserNicknameAsync(string userNickname);
    }
}
