using Domain.DrinkLine.ValueObject;
using FluentResults;
using MediatR;

namespace Application.MachinesWithDrinks.Commands.PurchaseDrinks;

public record PurchaseDrinksCommand(List<Purchase> Purchases, int[] Coins) : IRequest<Result<int>>;

public record Purchase(DrinkLineId DrinkLineId, int Quantity);
