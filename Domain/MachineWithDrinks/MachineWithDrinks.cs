using Domain.Common;
using Domain.MachineWithDrinks.Events;
using Domain.MachineWithDrinks.ValueObject;
using FluentResults;

namespace Domain.MachineWithDrinks;

public class MachineWithDrinks : AggregateRoot<MachineWithDrinksId>
{
    public int CoinsQuantity { get; private set; }

    private MachineWithDrinks()
        : base(MachineWithDrinksId.Create(0)) { }

    private MachineWithDrinks(MachineWithDrinksId machineWithDrinksId)
        : base(machineWithDrinksId) { }

    public static MachineWithDrinks CreateWithId(MachineWithDrinksId machineWithDrinksId)
    {
        return new MachineWithDrinks(machineWithDrinksId);
    }

    public Result<int> PurchaseDrinks(
        List<(DrinkLine.DrinkLine DrinkLine, int Quantity)> purchases,
        int coins
    )
    {
        int totalPrice = purchases.Aggregate(
            0,
            (totalPrice, purchase) =>
                totalPrice + purchase.Quantity * purchase.DrinkLine.Drink.Price.Value
        );

        if (totalPrice > coins)
        {
            return Result.Fail("Не достаточное количество монет для оплаты данного заказа");
        }

        CoinsQuantity += totalPrice;

        int change = coins - totalPrice;

        AddDomainEvent(new PurchasedDrinksDomainEvent(purchases));

        return change;
    }
}
