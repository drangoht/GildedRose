using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GildedRose.Console.TypedItems
{
    public class TypedItemFactory
    {
        private readonly IReadOnlyDictionary<string, ITypedItem> _items;

        public TypedItemFactory(List<Item> sourceItems) => _items = MapItemsToITypedItemDictionary(sourceItems);
        public ITypedItem Create(Item item) => GetItemByName(item.Name) ?? GetDefaultItem();



        private IReadOnlyDictionary<string, ITypedItem> MapItemsToITypedItemDictionary(List<Item> sourceItems)
        {
            IEnumerable<ITypedItem> itemsWithMatchingName = GetTypedItemsWithMatchingName(sourceItems);

            var sourcesItemsRemaining = sourceItems.Where(i => !itemsWithMatchingName.Any(c => c.Name == i.Name)).ToList();
            IEnumerable<ITypedItem> itemsWithDefaultName = GetDefaultTypedItems(sourcesItemsRemaining);

            var items = itemsWithMatchingName.Concat(itemsWithDefaultName);

            var result = items.ToImmutableDictionary(i => i.OriginalItem.Name, i => i);
            return result;

        }

        private IEnumerable<ITypedItem> GetTypedItemsWithMatchingName(List<Item> items) =>
            items.SelectMany
                (
                    i => GetAssignableTypedItemType().
                         Where(t => IsTypesAccordingToItemNameFound(t, i)),
                        (i, type) => (ITypedItem)Activator.CreateInstance(type, i)
                );

        private IEnumerable<ITypedItem> GetDefaultTypedItems(List<Item> items) => items.SelectMany
                (
                    i => GetAssignableTypedItemType().
                         Where(t => IsTypeAccordingToDefaultItem(t, i)),
                        (i, type) => (ITypedItem)Activator.CreateInstance(type, i)
                );

        private IEnumerable<Type> GetAssignableTypedItemType() =>
            typeof(ITypedItem).Assembly.ExportedTypes.Where(x => typeof(ITypedItem).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        private bool IsTypesAccordingToItemNameFound(Type type, Item item) =>
            ((ITypedItem)Activator.CreateInstance(type, item)).Name == item.Name;

        private bool IsTypeAccordingToDefaultItem(Type type, Item item) => ((ITypedItem)Activator.CreateInstance(type, item)).Name == "DefaultItem";

        private ITypedItem GetDefaultItem() => _items.GetValueOrDefault("DefaultItem");

        private ITypedItem GetItemByName(string name) => _items.GetValueOrDefault(name);
    }
}
