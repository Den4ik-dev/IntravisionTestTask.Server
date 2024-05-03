using Api.Common;
using Api.Common.Filter;
using Application.DrinkLines.Commands.AddDrinkLineImage;
using Application.DrinkLines.Commands.ChangeDrinkLine;
using Application.DrinkLines.Commands.CreateDrinkLine;
using Application.DrinkLines.Commands.RemoveDrinkLine;
using Application.DrinkLines.Queries.GetRangeOfDrinkLines;
using Contracts.DrinkLines;
using Domain.DrinkLine.ValueObject;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/drinkLines")]
public class DrinkLinesController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public DrinkLinesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [CustomAuthorize]
    [HttpPost("{drinkLineId:guid}/image")]
    public async Task<IResult> AddDrinkLineImage(IFormFile image, Guid drinkLineId)
    {
        string hostUrl = Request.Scheme + "://" + Request.Host;
        var command = new AddDrinkLineImageCommand(hostUrl, image, DrinkLineId.Create(drinkLineId));

        Result result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        return Results.Ok();
    }

    [CustomAuthorize]
    [HttpPost]
    public async Task<IResult> CreateDrinkLine(DrinkLineOfCreateDto drinkLineOfCreate)
    {
        CreateDrinkLineCommand command = _mapper.Map<CreateDrinkLineCommand>(drinkLineOfCreate);

        Result<DrinkLineId> result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        DrinkLineId drinkLineId = result.Value;

        return Results.Ok(drinkLineId.Value);
    }

    [CustomAuthorize]
    [HttpPut("{drinkLineId:guid}")]
    public async Task<IResult> ChangeDrinkLine(
        DrinkLineOfChangeDto drinkLineOfChange,
        Guid drinkLineId
    )
    {
        ChangeDrinkLineCommand command = _mapper.Map<ChangeDrinkLineCommand>(
            (drinkLineOfChange, drinkLineId)
        );

        Result result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        return Results.Ok();
    }

    [CustomAuthorize]
    [HttpDelete("{drinkLineId:guid}")]
    public async Task<IResult> RemoveDrinkLine(Guid drinkLineId)
    {
        var command = new RemoveDrinkLineCommand(DrinkLineId.Create(drinkLineId));

        Result result = await _sender.Send(command);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        return Results.Ok();
    }

    [HttpGet]
    public async Task<IResult> GetRangeOfDrinkLines(int page, int limit = 15)
    {
        var query = new GetRangeOfDrinkLinesQuery(page, limit);

        var result = await _sender.Send(query);

        if (result.IsFailed)
        {
            return Problem(result.Errors);
        }

        Response.Headers.Append("x-total-count", result.Value.TotalCount.ToString());
        return Results.Ok(result.Value.DrinkLines);
    }
}
