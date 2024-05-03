using FluentResults;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DrinkLines.Queries.GetRangeOfDrinkLines;

public class GetRangeOfDrinkLinesQueryHandler
    : IRequestHandler<
        GetRangeOfDrinkLinesQuery,
        Result<(IEnumerable<DrinkLineDto> DrinkLines, int TotalCount)>
    >
{
    private readonly ApplicationDbContext _context;

    public GetRangeOfDrinkLinesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<(IEnumerable<DrinkLineDto> DrinkLines, int TotalCount)>> Handle(
        GetRangeOfDrinkLinesQuery query,
        CancellationToken cancellationToken
    )
    {
        IEnumerable<DrinkLineDto> drinkLines = _context
            .DrinkLines.Skip((query.Page - 1) * query.Limit)
            .Take(query.Limit)
            .Select(dl => new DrinkLineDto(
                dl.Id.Value,
                dl.Drink.Name,
                dl.Drink.Image.Path,
                dl.Drink.Price.Value,
                dl.DrinksQuantityInMachine
            ));

        int totalCount = await _context.DrinkLines.CountAsync();

        return (drinkLines, totalCount);
    }
}
