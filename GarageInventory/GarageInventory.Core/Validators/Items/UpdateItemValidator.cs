using FluentValidation;
using GarageInventory.Core.DTOs.Items;

namespace GarageInventory.Core.Validators.Items
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemDto>
    {
        public UpdateItemValidator() 
        {
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(12);
        }
    }
}
