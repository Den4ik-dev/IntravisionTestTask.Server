using Domain.DrinkLine.ValueObject;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.DrinkLines.Commands.AddDrinkLineImage;

public record AddDrinkLineImageCommand(string HostUrl, IFormFile Image, DrinkLineId DrinkLineId)
    : IRequest<Result>;
