using GarageInventory.Core.Models.Items;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Models.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserTypes UserType { get; set; } = 0;

        public string Password { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}