using Domain.Common;
using Domain.DrinkLine.ValueObject;

namespace Domain.DrinkLine;

public class DrinkLine : AggregateRoot<DrinkLineId>
{
    public Drink Drink { get; private set; }

    public int DrinksQuantityInMachine { get; private set; }

    private DrinkLine()
        : base(DrinkLineId.CreateUnique()) { }

    private DrinkLine(DrinkLineId drinkId, Drink drink, int drinksQuantityInMachine)
        : base(drinkId)
    {
        Drink = drink;
        DrinksQuantityInMachine = drinksQuantityInMachine;
    }

    public static DrinkLine Create(Drink drink, int drinksQuantityInMachine = 0)
    {
        return new DrinkLine(DrinkLineId.CreateUnique(), drink, drinksQuantityInMachine);
    }

    public static DrinkLine CreateWithId(
        DrinkLineId drinkLineId,
        Drink drink,
        int drinksQuantityInMachine
    )
    {
        return new DrinkLine(drinkLineId, drink, drinksQuantityInMachine);
    }

    public void ReduceDrinksQuantity(int difference)
    {
        DrinksQuantityInMachine -= difference;
    }

    public void SetDrink(Drink drink)
    {
        Drink = drink;
    }
}
