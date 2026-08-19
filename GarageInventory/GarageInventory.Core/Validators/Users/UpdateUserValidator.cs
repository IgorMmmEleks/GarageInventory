using FluentValidation;
using GarageInventory.Core.DTOs.Users;

namespace GarageInventory.Core.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Login)
                .MaximumLength(30)
                .When(x => !string.IsNullOrWhiteSpace(x.Login));

            RuleFor(x => x.Name)
                .MaximumLength(16)
                .When(x => !string.IsNullOrWhiteSpace(x.Name));

            RuleFor(x => x.Surname)
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.Surname));

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(12)
                .When(x => !string.IsNullOrWhiteSpace(x.Password));

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.UserType)
                .Must(x => x > 0 && x <= 3)
                .When(x => x.UserType != 0);
        }
    }
}