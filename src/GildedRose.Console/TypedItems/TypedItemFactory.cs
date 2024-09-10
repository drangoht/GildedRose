using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GildedRose.Console.TypedItems
{
    public class TypedItemFactory
    {
        private readonly IReadOnlyDictionary<string, ITypedItem> _items ;

        public TypedItemFactory(List<Item> sourceItems) =>   _items = MapItemsToITypedItemDictionary(sourceItems);
        public ITypedItem Create(Item item) => GetItemByName(item.Name) ?? GetDefaultItem();


        private IEnumerable<Type> GetAssignableTypedItemType() =>
            typeof(ITypedItem).Assembly.ExportedTypes.Where(x => typeof(ITypedItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        
        private IReadOnlyDictionary<string,ITypedItem> MapItemsToITypedItemDictionary(List<Item> sourceItems) =>
            sourceItems.SelectMany
                (
                    i => GetAssignableTypedItemType().
                         Where(t => IsTypesAccordingToItemNameFound(t, i) || IsTypeAccordingToDefaultItem(t, i)), 
                        (i, type) => Activator.CreateInstance(type, i)
                )
                .Cast<ITypedItem>()
                .ToImmutableDictionary(i => i.Name, i => i);

        private bool IsTypesAccordingToItemNameFound(Type type, Item item) =>
            ((ITypedItem)Activator.CreateInstance(type, item)).Name == item.Name;

        private bool IsTypeAccordingToDefaultItem(Type type, Item item) => ((ITypedItem)Activator.CreateInstance(type, item)).Name == "DefaultItem";

        private ITypedItem GetDefaultItem() => _items.GetValueOrDefault("DefaultItem");

        private ITypedItem GetItemByName(string name) => _items.GetValueOrDefault(name);
    }
}
