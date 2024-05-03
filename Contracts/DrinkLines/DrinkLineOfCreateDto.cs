namespace Contracts.DrinkLines;

public record DrinkLineOfCreateDto(DrinkOfCreateDto Drink, int DrinksQuantityInMachine);

public record DrinkOfCreateDto(string Name, int Price);
