using Api.Common;
using Api.Common.Filter;
using Application.Nominals.Commands.SwitchNominalForBlock;
using Application.Nominals.Queries.GetAllNominals;
using Domain.Nominal.ValueObject;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/nominals")]
public class NominalsController : ApiController
{
    private readonly ISender _sender;

    public NominalsController(ISender sender)
    {
        _sender = sender;
    }

    [CustomAuthorize]
    [HttpPost("{nominal_id:int}/isBlcoked")]
    public async Task<IResult> SwitchNominalForBlock(int nominal_id)
    {
        var command = new SwitchNominalForBlockCommand(NominalId.Create(nominal_id));

        Result result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        return Results.Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<NominalDto>> GetAllNominals()
    {
        var query = new GetAllNominalsQuery();

        IEnumerable<NominalDto> result = await _sender.Send(query);

        return result;
    }
}
