using GarageInventory.Core.Models.Users;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Users
{
    public class CreateUserDto
    {
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserModel ToUserModel()
        {
            return new UserModel
            {
                Id = Guid.NewGuid(),
                Login = Login,
                Name = Name,
                Surname = Surname,
                Email = Email,
                Password = Password,
                UserType = UserTypes.Viewer // Default user type
            };
        }
    }
}
