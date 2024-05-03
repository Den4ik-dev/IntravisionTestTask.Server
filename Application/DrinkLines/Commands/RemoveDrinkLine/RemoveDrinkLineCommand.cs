using Domain.DrinkLine.ValueObject;
using FluentResults;
using MediatR;

namespace Application.DrinkLines.Commands.RemoveDrinkLine;

public record RemoveDrinkLineCommand(DrinkLineId DrinkLineId) : IRequest<Result>;
