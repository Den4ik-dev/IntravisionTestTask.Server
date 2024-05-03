using FluentValidation;

namespace Application.DrinkLines.Commands.CreateDrinkLine;

public class CreateDrinkLineCommandValidator : AbstractValidator<CreateDrinkLineCommand>
{
    public CreateDrinkLineCommandValidator()
    {
        RuleFor(dl => dl.Drink).NotNull();

        RuleFor(dl => dl.Drink.Name).NotNull().NotEmpty();

        RuleFor(dl => dl.Drink.Price.Value).Must(price => price > 0);

        RuleFor(dl => dl.DrinksQuantityInMachine).Must(quantity => quantity > 0);
    }
}
