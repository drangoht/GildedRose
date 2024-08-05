using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.TypedItems
{
    public static class TypedItemFactory
    {

        public static TypedItem Create(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItem(item);
                case "Aged Brie":
                    return new AgedBrieItem(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassesItem(item);
                case "Conjured":
                    return new ConjuredItem(item);
                default:
                    return new DefaultItem(item);
            }
        }
    }
}
