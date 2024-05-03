using Domain.Nominal;
using FluentResults;
using Infrastructure.Data;
using MediatR;

namespace Application.Nominals.Commands.SwitchNominalForBlock;

public class SwitchNominalForBlockCommandHandler
    : IRequestHandler<SwitchNominalForBlockCommand, Result>
{
    private readonly ApplicationDbContext _context;

    public SwitchNominalForBlockCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(
        SwitchNominalForBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        Nominal? nominal = await _context.Nominals.FindAsync(
            [request.NominalId],
            cancellationToken
        );

        if (nominal == null)
        {
            return Result.Fail("Номинал не найден");
        }

        nominal.SwitchBlock();
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
