using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal;

internal class BasicPolicy : IPackingItemsPolicy
{
    private const uint MaximumQuantityOfCloths = 7;

    public bool IsApplicable(PolicyData _)
    {
        return true;
    }

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    {
        return new List<PackingItem>
        {
            new("Pants", Math.Min(data.Days, MaximumQuantityOfCloths)),
            new("Socks", Math.Min(data.Days, MaximumQuantityOfCloths)),
            new("T-shirt", Math.Min(data.Days, MaximumQuantityOfCloths)),
            new("Trousers", data.Days < 7 ? 1u : 2u),
            new("Shampoo", 1),
            new("Toothpaste", 1),
            new("Toothbrush", 1),
            new("Towel", 1),
            new("Bag pack", 1),
            new("Passport", 1),
            new("Charger", 1)
        };
    }
}