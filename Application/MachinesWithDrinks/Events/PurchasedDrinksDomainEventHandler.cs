using Domain.MachineWithDrinks.Events;
using Infrastructure.Data;
using MediatR;

namespace Application.MachinesWithDrinks.Events;

public class PurchasedDrinksDomainEventHandler : INotificationHandler<PurchasedDrinksDomainEvent>
{
    private readonly ApplicationDbContext _context;

    public PurchasedDrinksDomainEventHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        PurchasedDrinksDomainEvent notification,
        CancellationToken cancellationToken
    )
    {
        notification.Purchases.ForEach(p => p.DrinkLine.ReduceDrinksQuantity(p.Quantity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
