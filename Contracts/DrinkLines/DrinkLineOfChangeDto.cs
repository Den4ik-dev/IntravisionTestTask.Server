namespace Contracts.DrinkLines;

public record DrinkLineOfChangeDto(DrinkOfChangeDto Drink, int DrinksQuantityInMachine);

public record DrinkOfChangeDto(string Name, int Price);
