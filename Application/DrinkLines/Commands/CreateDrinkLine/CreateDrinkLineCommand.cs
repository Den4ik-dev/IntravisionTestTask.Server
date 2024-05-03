using Domain.DrinkLine.ValueObject;
using FluentResults;
using MediatR;

namespace Application.DrinkLines.Commands.CreateDrinkLine;

public record CreateDrinkLineCommand(Drink Drink, int DrinksQuantityInMachine)
    : IRequest<Result<DrinkLineId>>;
