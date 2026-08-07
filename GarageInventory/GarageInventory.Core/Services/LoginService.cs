using GarageInventory.Core.Database.Interfaces;
using GarageInventory.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> LoginAsync(string nickName, string password)
        {
            var user = await _userRepository.GetByUserNicknameAsync(nickName);

            if (user == null)
                return false;

            return _passwordService.VerifyPassword(user, password);
        }
    }
}
