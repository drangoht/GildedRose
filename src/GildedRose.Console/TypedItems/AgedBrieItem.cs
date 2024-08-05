using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.TypedItems
{
    public class AgedBrieItem : TypedItem
    {
        public AgedBrieItem(Item item) : base(item)
        {
            OriginalItem = item;
        }

        public Item OriginalItem { get; set; }

        public override void UpdateQuality()
        {
            OriginalItem.Quality++;
            OriginalItem.SellIn--;
            base.UpdateQuality();
        }
    }
}
