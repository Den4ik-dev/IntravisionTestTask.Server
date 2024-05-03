using FluentValidation;
using Infrastructure.Data;

namespace Application.MachinesWithDrinks.Commands.PurchaseDrinks;

public class PurchaseDrinksCommandValidator : AbstractValidator<PurchaseDrinksCommand>
{
    public PurchaseDrinksCommandValidator(ApplicationDbContext context)
    {
        IEnumerable<int> unblockedNominals = context
            .Nominals.Where(n => !n.IsBlocked)
            .Select(n => n.Value);

        RuleFor(pd => pd.Coins)
            .NotNull()
            .Must(coins => coins.Count() > 0)
            .Must(coins => coins.Distinct().All(c => unblockedNominals.Contains(c)))
            .WithMessage("Номинал одной или нескольких монет заблокирован");

        RuleFor(pd => pd.Purchases)
            .Must(purchases => purchases.Count > 0)
            .Must(purchases =>
                purchases.All(purchase =>
                    purchase.Quantity > 0
                    && !string.IsNullOrEmpty(purchase.DrinkLineId.Value.ToString())
                )
            );
    }
}
