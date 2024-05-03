namespace Contracts.MachinesWithDrinks;

public record PurchaseDto(Guid DrinkLineId, int Quantity);

public record PurchaseDrinksDto(List<PurchaseDto> Purchases, int[] Coins);
