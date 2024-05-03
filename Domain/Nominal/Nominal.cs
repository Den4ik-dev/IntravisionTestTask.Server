using Domain.Common;
using Domain.Nominal.ValueObject;

namespace Domain.Nominal;

public class Nominal : AggregateRoot<NominalId>
{
    public int Value { get; }
    public bool IsBlocked { get; private set; }

    private Nominal()
        : base(NominalId.Create(0)) { }

    private Nominal(NominalId nominalId, int value, bool isBlocked)
        : base(nominalId)
    {
        Value = value;
        IsBlocked = isBlocked;
    }

    public static Nominal CreateWithId(NominalId nominalId, int value, bool isBlocked = false)
    {
        return new Nominal(nominalId, value, isBlocked);
    }

    public void SwitchBlock()
    {
        IsBlocked = !IsBlocked;
    }
}
