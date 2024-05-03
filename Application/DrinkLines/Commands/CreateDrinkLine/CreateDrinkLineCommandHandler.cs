using Domain.DrinkLine;
using Domain.DrinkLine.ValueObject;
using FluentResults;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DrinkLines.Commands.CreateDrinkLine;

public class CreateDrinkLineCommandHandler
    : IRequestHandler<CreateDrinkLineCommand, Result<DrinkLineId>>
{
    private readonly ApplicationDbContext _context;

    public CreateDrinkLineCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DrinkLineId>> Handle(
        CreateDrinkLineCommand request,
        CancellationToken cancellationToken
    )
    {
        if (
            await _context.DrinkLines.SingleOrDefaultAsync(
                dl => dl.Drink.Name == request.Drink.Name,
                cancellationToken
            ) != null
        )
        {
            return Result.Fail("Партия напитков с данным названием уже существует");
        }

        DrinkLine drinkLine = DrinkLine.Create(request.Drink, request.DrinksQuantityInMachine);
        await _context.DrinkLines.AddAsync(drinkLine, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return drinkLine.Id;
    }
}
