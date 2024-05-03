using Domain.Common;

namespace Domain.MachineWithDrinks.Events;

public record PurchasedDrinksDomainEvent(
    List<(DrinkLine.DrinkLine DrinkLine, int Quantity)> Purchases
) : IDomainEvent;
