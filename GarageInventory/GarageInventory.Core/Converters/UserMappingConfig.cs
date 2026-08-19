using GarageInventory.Core.DTOs.Users;
using GarageInventory.Persistence.Abstract.Models;
using GarageInventory.Shared.Enums;
using Mapster;

namespace GarageInventory.Core.Converters
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserModel, UserDto>()
                .Map(dest => dest.Login, src => src.Login)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Surname, src => src.Surname)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.UserType, src => src.UserType)
                .Map(dest => dest.UserTypeName, src => src.UserType.ToString());

            config.NewConfig<CreateUserDto, UserModel>()
                .Map(dest => dest.Id, src => Guid.NewGuid())
                .Map(dest => dest.Login, src => src.Login)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Surname, src => src.Surname)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.UserType, src => UserTypes.Viewer);

            config.NewConfig<UpdateUserDto, UserModel>()
                .Map(dest => dest.Login, src => src.Login, srcCond => !string.IsNullOrEmpty(srcCond.Login))
                .Map(dest => dest.Name, src => src.Name, srcCond => !string.IsNullOrEmpty(srcCond.Name))
                .Map(dest => dest.Surname, src => src.Surname, srcCond => !string.IsNullOrEmpty(srcCond.Surname))
                .Map(dest => dest.Email, src => src.Email, srcCond => !string.IsNullOrEmpty(srcCond.Email))
                .Map(dest => dest.UserType, src => (UserTypes)src.UserType, srcCond => (UserTypes)srcCond.UserType != 0);
        }
    }
}
