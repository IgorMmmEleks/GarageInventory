using FluentValidation;
using GarageInventory.Core.DTOs.Tools;

namespace GarageInventory.Core.Validators.Tools
{
    public class CreateToolItemValidator : AbstractValidator<CreateItemToolDto>
    {
        public CreateToolItemValidator()
        {
            RuleFor(x => x.ItemSubType)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ItemGroupId)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ItemGroupId.HasValue);

            RuleFor(x => x.ItemCondition)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ManufactureId)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ManufactureId.HasValue);

            RuleFor(x => x.ToolDto)
                .NotNull();

            RuleFor(x => x.ToolDto.Description)
                .MaximumLength(120);

            RuleFor(x => x.ToolDto.ToolType)
                .NotNull()
                .IsInEnum();

            RuleFor(x => x.ToolDto.ToolStandart)
                .NotNull()
                .IsInEnum();

            RuleFor(x => x.ToolDto.ToolName)
                .MaximumLength(60);

            RuleFor(x => x.ToolDto.ToolSpec)
                .MaximumLength(120);

        }
    }
}