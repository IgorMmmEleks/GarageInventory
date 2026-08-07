using GarageInventory.Core.Database.Interfaces;
using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Models.Users;
using GarageInventory.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace GarageInventory.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<UserModel> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> UserExistsAsync(string userEmail)
        {
            return await _userRepository.ExistsAsync(userEmail);
        }

        public async Task<UserDto?> ValidateCredentialsAsync(
            string login,
            string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetByUserNicknameAsync(login);

            if (user == null)
                return null;

            var valid = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password);

            if (valid == PasswordVerificationResult.Failed)
                return null;

            return new UserDto
            {
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserType = user.UserType
            };
        }

        public async Task<UserModel> CreateAsync(CreateUserDto userDto)
        {
            var user = userDto.ToUserModel();

            user.PasswordHash = _passwordHasher.HashPassword(user, userDto.Password);
            user.IsActive = true;

            var userId = await _userRepository.CreateAsync(user);

            if(userId == null)
            {
                throw new Exception("Failed to create user."); //!!!
            }

            return user;
        }




        public Task<bool> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByNicknameAsync(string nickname)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUserAsync(Guid userId, UpdateUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
