using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<PackingListId>
{
    private readonly LinkedList<PackingItem> _items = new();

    private readonly PackingListName _name;
    private Localization _localization;

    private PackingList(PackingListId id, PackingListName name, Localization localization,
        LinkedList<PackingItem> items) : this(id, name, localization)
    {
        _items = items;
    }

    internal PackingList(PackingListId id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    private PackingList()
    {
    }

    public new PackingListId Id { get; }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = _items.Any(i => i.Name == item.Name);
        if (alreadyExists)
            throw new PackingItemAlreadyExistsException(_name, item.Name);

        _items.AddLast(item);
        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingItem> packingItems)
    {
        foreach (var packingItem in packingItems)
            AddItem(packingItem);
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);
        var packedItem = item with { IsPacked = true };

        _items.Find(item)!.Value = packedItem;
        AddEvent(new PackingItemPacked(this, item));
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);
        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingItem GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(i => i.Name == itemName);

        if (item == null)
            throw new PackingItemNotFoundException(itemName);

        return item;
    }
}