using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.TypedItems
{
    internal class SulfurasItem : TypedItem
    {
        public SulfurasItem(Item item) : base(item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }
        public override void UpdateQuality()
        {
            return;
        }
    }
}
