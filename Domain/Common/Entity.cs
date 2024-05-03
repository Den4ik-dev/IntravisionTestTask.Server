namespace Domain.Common;

public abstract class Entity<TId> : IHasDomainEvent, IEquatable<Entity<TId>>
    where TId : notnull
{
    private readonly List<IDomainEvent> domainEvents = new();

    public IReadOnlyList<IDomainEvent> DomainEvents => domainEvents;
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public void ClearDomainEvents()
    {
        domainEvents.Clear();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents.Add(domainEvent);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Entity<TId>? entity)
    {
        return Equals((object?)entity);
    }
}
