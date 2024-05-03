namespace Domain.DrinkLine.ValueObject;

public class Price : Common.ValueObject
{
    public int Value { get; }

    private Price(int value)
    {
        Value = value;
    }

    public static Price Create(int value)
    {
        return new Price(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
