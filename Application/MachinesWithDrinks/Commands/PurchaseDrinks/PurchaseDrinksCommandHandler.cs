using Domain.DrinkLine;
using Domain.DrinkLine.ValueObject;
using FluentResults;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MachinesWithDrinks.Commands.PurchaseDrinks;

public class PurchaseDrinksCommandHandler : IRequestHandler<PurchaseDrinksCommand, Result<int>>
{
    private readonly ApplicationDbContext _context;

    public PurchaseDrinksCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(
        PurchaseDrinksCommand request,
        CancellationToken cancellationToken
    )
    {
        // Можно улучшить проверку
        IEnumerable<DrinkLineId> drinkLineIds = request.Purchases.Select(p => p.DrinkLineId);
        List<DrinkLine> drinkLines = _context
            .DrinkLines.Where(dl => drinkLineIds.Contains(dl.Id))
            .ToList();

        if (
            request.Purchases.Any(p =>
                !drinkLines.Any(dl =>
                    p.DrinkLineId == dl.Id && p.Quantity <= dl.DrinksQuantityInMachine
                )
            )
        )
        {
            return Result.Fail("В автомате нет таких напитков");
        }

        List<(DrinkLine DrinkLine, int Quantity)> purchases = drinkLines
            .Join(
                request.Purchases,
                drinkLine => drinkLine.Id,
                purchase => purchase.DrinkLineId,
                (drinkLine, purchase) => (drinkLine, purchase.Quantity)
            )
            .ToList();

        var machineWithDrinks = await _context.MachinesWithDrinks.FirstAsync(cancellationToken);
        Result<int> result = machineWithDrinks.PurchaseDrinks(purchases, request.Coins.Sum());

        if (result.IsSuccess)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return result;
    }
}
