namespace Domain.DrinkLine.ValueObject;

public class Drink : Common.ValueObject
{
    public string Name { get; private set; }
    public Image? Image { get; private set; }
    public Price Price { get; private set; }

    private Drink(string name, Price price, Image? image)
    {
        Name = name;
        Price = price;
        Image = image;
    }

    public static Drink Create(string name, Price price, Image? image = null)
    {
        return new Drink(name, price, image);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Image;
        yield return Price;
    }
}
