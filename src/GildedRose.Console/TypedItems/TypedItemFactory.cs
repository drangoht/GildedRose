using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GildedRose.Console.TypedItems
{
    public class TypedItemFactory
    {
        private readonly IReadOnlyDictionary<string, ITypedItem> _items ;

        public TypedItemFactory(List<Item> sourceItems)
        {
            var typedItemType = typeof(ITypedItem);
            var types = typedItemType.Assembly.ExportedTypes.Where(x => typedItemType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            
            _items = sourceItems
                .SelectMany(i => types
                    .Where(t => ((ITypedItem)Activator.CreateInstance(t, i)).Name == i.Name ), (i,type) =>  
                Activator.CreateInstance(type, i))
                .Cast<ITypedItem>()
                .ToImmutableDictionary(i =>i.Name, i => i);
            
            
            //_items = typedItemType.Assembly.ExportedTypes
            //    .Where(x => typedItemType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            //    .Select(x => Activator.CreateInstance(x))
            //    .Cast<TypedItem>()
            //    .ToImmutableDictionary(x => x.Name, x => x);
        }
        public ITypedItem Create(Item item)
        {
            var itemFound = _items.GetValueOrDefault(item.Name);
            return itemFound ?? _items.GetValueOrDefault("DefaultItem");

        }
    }
}
