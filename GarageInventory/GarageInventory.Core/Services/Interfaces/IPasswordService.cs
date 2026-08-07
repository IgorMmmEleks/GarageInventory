using GarageInventory.Core.Models.Users;

namespace GarageInventory.Core.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(UserModel user, string password);
        bool VerifyPassword(UserModel user, string password);
    }
}
