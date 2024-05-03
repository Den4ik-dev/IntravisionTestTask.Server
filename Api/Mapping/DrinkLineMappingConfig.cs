using Application.DrinkLines.Commands.AddDrinkLineImage;
using Application.DrinkLines.Commands.ChangeDrinkLine;
using Application.DrinkLines.Commands.CreateDrinkLine;
using Contracts.DrinkLines;
using Domain.DrinkLine.ValueObject;
using Mapster;

namespace Api.Mapping;

public class DrinkLineMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, DrinkLineId>().MapWith(src => DrinkLineId.Create(src));

        config
            .NewConfig<DrinkOfCreateDto, Drink>()
            .MapWith(src => Drink.Create(src.Name, Price.Create(src.Price), null));

        config
            .NewConfig<DrinkOfChangeDto, Drink>()
            .MapWith(src => Drink.Create(src.Name, Price.Create(src.Price), null));

        config
            .NewConfig<
                (DrinkLineOfChangeDto DrinkLineOfChange, Guid DrinkLineId),
                ChangeDrinkLineCommand
            >()
            .Map(dest => dest.Drink, src => src.DrinkLineOfChange.Drink)
            .Map(
                dest => dest.DrinksQuantityInMachine,
                src => src.DrinkLineOfChange.DrinksQuantityInMachine
            )
            .Map(dest => dest.DrinkLineId, src => src.DrinkLineId);
    }
}
