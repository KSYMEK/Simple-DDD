using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions;

public class PackingListNotFoundException : PackItException
{
    public PackingListNotFoundException(Guid packingList) : base(
        $"Packing list with id '{packingList} cannot be found.'")
    {
        PackingList = packingList;
    }

    public Guid PackingList { get; }
}