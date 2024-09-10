using GildedRose.Console.TypedItems.Extensions;

namespace GildedRose.Console.TypedItems
{
    public class ConjuredItem : ITypedItem
    {
        public ConjuredItem(Item item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public void UpdateQuality()
        {
            OriginalItem.Quality -= 2;
            OriginalItem.SellIn--;
            OriginalItem.BoundQualityLimits();
        }
        public string Name { get => "Conjured Mana Cake"; }
    }
}
