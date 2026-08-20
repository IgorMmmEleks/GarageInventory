using FluentValidation;
using GarageInventory.Core.DTOs.Items;

namespace GarageInventory.Core.Validators.Items
{
    public class CreateItemValidator : AbstractValidator<CreateItemDto>
    {
        public CreateItemValidator()
        {
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(12);
        }
    }
}
