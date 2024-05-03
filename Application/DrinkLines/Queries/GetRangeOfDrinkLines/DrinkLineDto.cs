namespace Application.DrinkLines.Queries.GetRangeOfDrinkLines;

public record DrinkLineDto(
    Guid Id,
    string Name,
    string ImagePath,
    int Price,
    int DrinksQuantityInMachine
);
