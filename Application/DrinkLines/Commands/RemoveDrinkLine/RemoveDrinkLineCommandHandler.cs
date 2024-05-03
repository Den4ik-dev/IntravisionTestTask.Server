using Domain.DrinkLine;
using FluentResults;
using Infrastructure.Data;
using MediatR;

namespace Application.DrinkLines.Commands.RemoveDrinkLine;

public class RemoveDrinkLineCommandHandler : IRequestHandler<RemoveDrinkLineCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public RemoveDrinkLineCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(
        RemoveDrinkLineCommand request,
        CancellationToken cancellationToken
    )
    {
        DrinkLine? removedDrinkLine = await _context.DrinkLines.FindAsync(
            [request.DrinkLineId],
            cancellationToken
        );

        if (removedDrinkLine == null)
        {
            return Result.Fail("Партия напитков не найдена");
        }

        _context.DrinkLines.Remove(removedDrinkLine);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
