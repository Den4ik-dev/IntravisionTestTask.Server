namespace Domain.DrinkLine.ValueObject;

public class Image : Common.ValueObject
{
    public string Path { get; private set; }

    private Image(string path)
    {
        Path = path;
    }

    public static Image Create(string path)
    {
        return new Image(path);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Path;
    }
}
