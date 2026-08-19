using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;
using GarageInventory.Persistence.Abstract.Models;
using Microsoft.AspNetCore.Identity;
using MapsterMapper;
using GarageInventory.Shared.Enums;
using Mapster;

namespace GarageInventory.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public UserService(IMapper mapper, IUserRepository userRepository, IPasswordHasher<UserModel> passwordHasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto?> ValidateCredentialsAsync(string login, string password)
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

            return _mapper.Map<UserModel, UserDto>(user);
        }

        public async Task<OperationResult<List<UserDto>>> GetAllAsync(int skip, int take)
        {
            try {

                var userList = await _userRepository.GetAllAsync(skip, take);

                if (userList == null)
                    return OperationResult<List<UserDto>>.Failure(OperationResultErrors.Failed);

                return OperationResult<List<UserDto>>.Success(_mapper.Map<List<UserModel>, List<UserDto>>(userList.ToList()));
            }
            catch (Exception ex) {
                return OperationResult<List<UserDto>>.Exception(ex);
            }
        }

        public async Task<OperationResult<UserDto>> GetAsync(string userLogin)
        {
            try {

                var user = await _userRepository.GetByUserLoginAsync(userLogin);

                if (user == null)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.NotFound);

                return OperationResult<UserDto>.Success(_mapper.Map<UserModel, UserDto>(user));
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

                var user = _mapper.Map<CreateUserDto, UserModel>(createUserDto);

                user.PasswordHash = _passwordHasher.HashPassword(user, createUserDto.Password);

                var userId = await _userRepository.CreateAsync(user);

                if (userId == null)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.Failed);

                return OperationResult<UserDto>.Success(_mapper.Map<UserModel, UserDto>(user));
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

                updateUserDto.Adapt(user);

                if(!string.IsNullOrEmpty(updateUserDto.Password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, updateUserDto.Password);

                var result = await _userRepository.UpdateAsync(user);

                if(!result)
                    return OperationResult<UserDto>.Failure(OperationResultErrors.Failed);

                return OperationResult<UserDto>.Success(_mapper.Map<UserModel, UserDto>(user));
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
