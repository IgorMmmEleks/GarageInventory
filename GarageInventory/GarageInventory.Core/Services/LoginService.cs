using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Interfaces;

namespace GarageInventory.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService = new PasswordService();

        public LoginService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<bool> LoginAsync(string login, string password)
        {
            var user = await _userRepository.GetByUserLoginAsync(login);

            if (user == null)
                return false;

            return _passwordService.VerifyPassword(user, password);
        }
    }
}
