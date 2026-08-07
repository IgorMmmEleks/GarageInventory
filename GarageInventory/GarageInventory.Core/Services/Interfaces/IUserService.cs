using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Models.Users;

namespace GarageInventory.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> ValidateCredentialsAsync(string login, string password);
        Task<bool> UserExistsAsync(string userEmail);
        Task<UserModel> CreateAsync(CreateUserDto user);
        Task<UserModel> GetUserByNicknameAsync(string nickname);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> UpdateUserAsync(Guid userId, UpdateUserDto user);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
