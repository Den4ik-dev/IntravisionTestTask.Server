using Domain.DrinkLine;
using Domain.DrinkLine.ValueObject;
using FluentResults;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DrinkLines.Commands.ChangeDrinkLine;

public class ChangeDrinkLineCommandHandler : IRequestHandler<ChangeDrinkLineCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public ChangeDrinkLineCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(
        ChangeDrinkLineCommand request,
        CancellationToken cancellationToken
    )
    {
        if (
            await _context.DrinkLines.SingleOrDefaultAsync(
                dl => dl.Drink.Name == request.Drink.Name && dl.Id != request.DrinkLineId,
                cancellationToken
            ) != null
        )
        {
            return Result.Fail("Партия напитков с данным названием уже существует");
        }

        DrinkLine? drinkLine = await _context
            .DrinkLines.AsNoTracking()
            .FirstOrDefaultAsync(dl => dl.Id == request.DrinkLineId, cancellationToken);

        if (drinkLine == null)
        {
            return Result.Fail("Партия напитков не найдена");
        }

        DrinkLine changedDrinkLine = DrinkLine.CreateWithId(
            drinkLine.Id,
            Drink.Create(request.Drink.Name, request.Drink.Price, drinkLine.Drink.Image),
            request.DrinksQuantityInMachine
        );

        _context.DrinkLines.Update(changedDrinkLine);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
