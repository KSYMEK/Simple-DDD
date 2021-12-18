using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListItemException : PackItException
{
    public EmptyPackingListItemException() : base("Packing list item cannot be empty.")
    {
    }
}