using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
    {
        return data.Gender is Consts.Gender.Male;
    }

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    {
        return new List<PackingItem>
        {
            new("Laptop", 1),
            new("Beer", 10),
            new("Book", (uint)Math.Ceiling(data.Days / 7m))
        };
    }
}