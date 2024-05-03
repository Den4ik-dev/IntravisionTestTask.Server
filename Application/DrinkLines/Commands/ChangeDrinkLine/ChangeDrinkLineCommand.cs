using Domain.DrinkLine.ValueObject;
using FluentResults;
using MediatR;

namespace Application.DrinkLines.Commands.ChangeDrinkLine;

public record ChangeDrinkLineCommand(
    Drink Drink,
    int DrinksQuantityInMachine,
    DrinkLineId DrinkLineId
) : IRequest<Result>;
