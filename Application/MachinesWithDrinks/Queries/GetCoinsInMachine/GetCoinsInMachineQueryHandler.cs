using Infrastructure.Data;
using MediatR;

namespace Application.MachinesWithDrinks.Queries.GetCoinsInMachine;

public class GetCoinsInMachineQueryHandler : IRequestHandler<GetCoinsInMachineQuery, int>
{
    private readonly ApplicationDbContext _context;

    public GetCoinsInMachineQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(GetCoinsInMachineQuery query, CancellationToken cancellationToken)
    {
        return _context.MachinesWithDrinks.First().CoinsQuantity;
    }
}
