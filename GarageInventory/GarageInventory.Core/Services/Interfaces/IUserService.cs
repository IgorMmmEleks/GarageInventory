using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Results;

namespace GarageInventory.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> ValidateCredentialsAsync(string login, string password);

        Task<OperationResult<List<UserDto>>> GetAllAsync(int skip, int take);

        Task<OperationResult<UserDto>> GetAsync(string userLogin);

        Task<OperationResult<UserDto>> CreateAsync(CreateUserDto createUserDto);

        Task<OperationResult<UserDto>> UpdateAsync(UpdateUserDto updateUserDto);

        Task<OperationResult<UserDto>> DeleteAsync(Guid userId);
    }
}