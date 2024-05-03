using Infrastructure.Data;
using MediatR;

namespace Application.Nominals.Queries.GetAllNominals;

public class GetAllNominalsQueryHandler
    : IRequestHandler<GetAllNominalsQuery, IEnumerable<NominalDto>>
{
    private readonly ApplicationDbContext _context;

    public GetAllNominalsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NominalDto>> Handle(
        GetAllNominalsQuery query,
        CancellationToken cancellationToken
    )
    {
        return _context.Nominals.Select(nominal => new NominalDto(
            nominal.Id.Value,
            nominal.Value,
            nominal.IsBlocked
        ));
    }
}
