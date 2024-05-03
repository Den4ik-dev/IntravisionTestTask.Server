using Api.Common;
using Application.MachinesWithDrinks.Commands.PurchaseDrinks;
using Contracts.MachinesWithDrinks;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/machineWithDrinks")]
public class MachineWithDrinksController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public MachineWithDrinksController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost("purchases")]
    public async Task<IResult> PurchaseDrinks(PurchaseDrinksDto purchase)
    {
        PurchaseDrinksCommand command = _mapper.Map<PurchaseDrinksCommand>(purchase);

        Result<int> result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        int change = result.Value;

        return Results.Ok(change);
    }
}
