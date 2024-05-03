using FluentResults;
using MediatR;

namespace Application.DrinkLines.Queries.GetRangeOfDrinkLines;

public record GetRangeOfDrinkLinesQuery(int Page, int Limit)
    : IRequest<Result<(IEnumerable<DrinkLineDto> DrinkLines, int TotalCount)>>;
