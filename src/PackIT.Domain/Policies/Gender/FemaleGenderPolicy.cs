using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
    {
        return data.Gender is Consts.Gender.Female;
    }

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
    {
        return new List<PackingItem>
        {
            new("Eyeliner", 1),
            new("Boots", 3)
        };
    }
}