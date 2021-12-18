namespace PackIT.Infrastructure.EF.Models;

internal class LocalizationReadModel
{
    public string City { get; set; }
    public string Country { get; set; }

    public static LocalizationReadModel Create(string value)
    {
        var split = value.Split(",");
        return new LocalizationReadModel
        {
            City = split.First(),
            Country = split.Last()
        };
    }

    public override string ToString()
    {
        return $"{City},{Country}";
    }
}