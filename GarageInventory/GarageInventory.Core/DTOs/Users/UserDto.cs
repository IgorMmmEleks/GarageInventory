using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }

        public UserTypes UserType { get; set; } = 0;
        public string? UserTypeName {
            get
            {
                return UserType.ToString();
            }
        }
    }
}
