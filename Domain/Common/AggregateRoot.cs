namespace Domain.Common;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    protected AggregateRoot(TId id)
        : base(id) { }
}
