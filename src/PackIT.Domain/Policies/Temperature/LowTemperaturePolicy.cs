using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class LowTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
    {
        return data.Temperature < 10;
    }

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    {
        return new List<PackingItem>
        {
            new("Hat", 1),
            new("Scarf", 1),
            new("Gloves", 1)
        };
    }
}