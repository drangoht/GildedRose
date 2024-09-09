using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GildedRose.Console.TypedItems
{
    public class TypedItemFactory
    {
        private readonly IReadOnlyDictionary<string, TypedItem> _items ;

        public TypedItemFactory(Item item)
        {
            var typedItemType = typeof(TypedItem);
            _items = typedItemType.Assembly.ExportedTypes
                .Where(x => typedItemType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x,item))
                .Cast<TypedItem>()
                .ToImmutableDictionary(x => x.Name, x => x);
        }
        public TypedItem Create(Item item) => _items.GetValueOrDefault(item.Name);    
    }
}
