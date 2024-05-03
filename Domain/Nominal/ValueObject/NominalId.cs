namespace Domain.Nominal.ValueObject;

public class NominalId : Common.ValueObject
{
    public int Value { get; }

    private NominalId(int value)
    {
        Value = value;
    }

    public static NominalId Create(int value)
    {
        return new NominalId(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
