using Domain.DrinkLine;
using Domain.DrinkLine.ValueObject;
using FluentResults;
using Infrastructure.Data;
using Infrastructure.Services;
using MediatR;

namespace Application.DrinkLines.Commands.AddDrinkLineImage;

public class AddDrinkLineImageCommandHandler : IRequestHandler<AddDrinkLineImageCommand, Result>
{
    private readonly UploadService _uploadService;
    private readonly ApplicationDbContext _context;

    public AddDrinkLineImageCommandHandler(
        UploadService uploadService,
        ApplicationDbContext context
    )
    {
        _uploadService = uploadService;
        _context = context;
    }

    public async Task<Result> Handle(
        AddDrinkLineImageCommand request,
        CancellationToken cancellationToken
    )
    {
        DrinkLine? drinkLine = await _context.DrinkLines.FindAsync(
            [request.DrinkLineId],
            cancellationToken
        );

        if (drinkLine is null)
        {
            return Result.Fail("Напитки с данным названием не найдены");
        }

        string imageNameWithExtension = await _uploadService.UploadFile(
            request.Image,
            request.DrinkLineId.Value.ToString()
        );

        string imagePath = request.HostUrl + "/drinkLineImages/" + imageNameWithExtension;
        drinkLine.SetDrink(
            Drink.Create(drinkLine.Drink.Name, drinkLine.Drink.Price, Image.Create(imagePath))
        );

        await _context.SaveChangesAsync();

        return Result.Ok();
    }
}
