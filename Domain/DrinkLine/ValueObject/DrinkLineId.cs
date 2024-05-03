namespace Domain.DrinkLine.ValueObject;

public class DrinkLineId : Common.ValueObject
{
    public Guid Value { get; }

    private DrinkLineId(Guid value)
    {
        Value = value;
    }

    public static DrinkLineId CreateUnique()
    {
        return new DrinkLineId(Guid.NewGuid());
    }

    public static DrinkLineId Create(Guid value)
    {
        return new DrinkLineId(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
