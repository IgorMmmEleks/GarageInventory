using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models;
using Microsoft.AspNetCore.Identity;
using GarageInventory.Shared.Enums;

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

        public async Task<UserDto?> ValidateCredsAndGetAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetByUserLoginAsync(login);

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
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserType = user.UserType
                };
        }

        public async Task<OperationResult<IEnumerable<UserDto>>> GetAllAsync(int skip, int take)
        {
            try {

                var userList = await _userRepository.GetAllAsync(skip, take);

                if (userList == null)
                    return OperationResult<IEnumerable<UserDto>>.Failure(OperationResultErrors.Failed);

                var result = userList.Select(u =>
                    new UserDto
                    {
                        Id = u.Id,
                        Login = u.Login,
                        Name = u.Name,
                        Surname = u.Surname,
                        Email = u.Email,
                        UserType = u.UserType
                    });

                return OperationResult<IEnumerable<UserDto>>.Success(result);
            }
            catch (Exception ex) {
                return OperationResult<IEnumerable<UserDto>>.Exception(ex);
            }
        }

        public async Task<OperationResult<UserDto>> GetAsync(string userLogin)
        {
            try {

                var user = await _userRepository.GetByUserLoginAsync(userLogin);

                if (user == null)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.NotFound);

                var result = new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserType = user.UserType
                };

                return OperationResult<UserDto>.Success(result);
            }
            catch (Exception ex) {
                return OperationResult<UserDto>.Exception(ex);
            }
        }

        public async Task<OperationResult<UserDto>> CreateAsync(CreateUserDto createUserDto)
        {
            try {

                if (await _userRepository.ExistsAsync(createUserDto.Email))
                    return OperationResult<UserDto>.Failure(OperationResultErrors.AlreadyExists);

                var user = new UserModel
                {
                    Id = Guid.NewGuid(),
                    Login = createUserDto.Login,
                    Name = createUserDto.Name,
                    Surname = createUserDto.Surname,
                    Email = createUserDto.Email,
                    UserType = UserTypes.Viewer
                };

                user.PasswordHash = _passwordHasher.HashPassword(user, createUserDto.Password);

                var userId = await _userRepository.CreateAsync(user);

                if (userId == null)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.Failed);

                var result = new UserDto
                {
                    Id = userId.Value,
                    Login = user.Login,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserType = user.UserType,
                    PasswordHash = user.PasswordHash
                };

                return OperationResult<UserDto>.Success(result);
            }
            catch (Exception ex) {
                return OperationResult<UserDto>.Exception(ex);
            }
        }

        public async Task<OperationResult<UserDto>> UpdateAsync(UpdateUserDto updateUserDto)
        {
            try {

                var user = await _userRepository.GetByUserLoginAsync(updateUserDto.Login);

                if(user == null)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.NotFound);

                user.Login = string.IsNullOrEmpty(updateUserDto.Login) ? user.Login : updateUserDto.Login;
                user.Surname = string.IsNullOrEmpty(updateUserDto.Surname) ? user.Surname : updateUserDto.Surname;
                user.Email = string.IsNullOrEmpty(updateUserDto.Email) ? user.Email : updateUserDto.Email;
                user.UserType = updateUserDto.UserType == 0 ? user.UserType : (UserTypes)updateUserDto.UserType;

                if (!string.IsNullOrEmpty(updateUserDto.Password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, updateUserDto.Password);

                var updateResult = await _userRepository.UpdateAsync(user);

                if(!updateResult)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.Failed);

                var result = new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserType = user.UserType,
                    PasswordHash = user.PasswordHash
                };

                return OperationResult<UserDto>.Success(result);
            }
            catch (Exception ex) {
                return OperationResult<UserDto>.Exception(ex);
            }
        }

        public async Task<OperationResult<UserDto>> DeleteAsync(Guid userId)
        {
            try {

                var result = await _userRepository.DeleteAsync(userId);

                return result
                    ? OperationResult<UserDto>.Success(new UserDto())
                    : OperationResult<UserDto>.Failure(OperationResultErrors.Failed);
            }
            catch (Exception ex) {
                return OperationResult<UserDto>.Exception(ex);
            }
        }
    }
}
