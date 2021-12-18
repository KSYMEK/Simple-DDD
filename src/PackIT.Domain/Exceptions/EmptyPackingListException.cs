using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListException : PackItException
{
    public EmptyPackingListException() : base("Packing list name cannot be empty.")
    {
    }
}