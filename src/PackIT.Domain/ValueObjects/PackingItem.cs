using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record PackingItem
{
    public PackingItem(string name, uint quantity, bool isPacked = false)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyPackingListItemException();

        Name = name;
        Quantity = quantity;
        IsPacked = isPacked;
    }

    public string Name { get; }
    public uint Quantity { get; }
    public bool IsPacked { get; init; }
}