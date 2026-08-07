using FluentValidation;
using GarageInventory.Core.DTOs.Users;

namespace GarageInventory.Core.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(16);
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(12);
        }
    }
}
