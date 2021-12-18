using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class HighTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
    {
        return data.Temperature > 250;
    }

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    {
        return new List<PackingItem>
        {
            new("Hat", 1),
            new("Sunglasses", 1),
            new("Oil", 1)
        };
    }
}