using FluentValidation;

namespace Application.DrinkLines.Commands.ChangeDrinkLine;

public class ChangeDrinkLineCommandValidator : AbstractValidator<ChangeDrinkLineCommand>
{
    public ChangeDrinkLineCommandValidator()
    {
        RuleFor(dl => dl.Drink).NotNull();

        RuleFor(dl => dl.Drink.Name).NotNull().NotEmpty();

        RuleFor(dl => dl.Drink.Price.Value).Must(price => price > 0);

        RuleFor(dl => dl.DrinksQuantityInMachine).Must(quantity => quantity > 0);

        RuleFor(dl => dl.DrinkLineId.Value).NotNull().NotEmpty();
    }
}
