using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Persistence.Abstract.Models;
using Microsoft.AspNetCore.Identity;

namespace GarageInventory.Core.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<UserModel> _hasher = new();

        public string HashPassword(UserModel user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(UserModel user, string password)
        {
            var result = _hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            password);

            return result == PasswordVerificationResult.Success;
        }
    }
}
