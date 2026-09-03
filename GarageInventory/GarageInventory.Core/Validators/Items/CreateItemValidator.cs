using FluentValidation;
using GarageInventory.Core.DTOs.Items;

namespace GarageInventory.Core.Validators.Items
{
    public class CreateItemValidator : AbstractValidator<CreateItemDto>
    {
        public CreateItemValidator()
        {

        }
    }
}
