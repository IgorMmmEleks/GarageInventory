using GarageInventory.Shared.Enums;

namespace GarageInventory.Persistence.Abstract.Models;

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserTypes UserType { get; set; } = 0;
        public string PasswordHash { get; set; } = string.Empty;
    }