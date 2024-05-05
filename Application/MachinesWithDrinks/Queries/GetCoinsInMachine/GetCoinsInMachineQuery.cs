using MediatR;

namespace Application.MachinesWithDrinks.Queries.GetCoinsInMachine;

public record GetCoinsInMachineQuery() : IRequest<int>;
