using MediatR;

namespace Application.Nominals.Queries.GetAllNominals;

public record GetAllNominalsQuery() : IRequest<IEnumerable<NominalDto>>;
