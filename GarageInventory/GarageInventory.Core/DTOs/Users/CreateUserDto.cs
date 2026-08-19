using GarageInventory.Persistence.Abstract.Models;
using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.DTOs.Users
{
    public class CreateUserDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
