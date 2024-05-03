using FluentValidation;

namespace Application.DrinkLines.Commands.RemoveDrinkLine;

public class RemoveDrinkLineCommandValidator : AbstractValidator<RemoveDrinkLineCommand>
{
    public RemoveDrinkLineCommandValidator()
    {
        RuleFor(dl => dl.DrinkLineId.Value).NotNull().NotEmpty();
    }
}
