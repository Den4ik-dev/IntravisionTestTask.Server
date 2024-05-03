namespace Domain.MachineWithDrinks.ValueObject;

public class MachineWithDrinksId : Common.ValueObject
{
    public int Value { get; }

    private MachineWithDrinksId(int value)
    {
        Value = value;
    }

    public static MachineWithDrinksId Create(int value)
    {
        return new MachineWithDrinksId(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
