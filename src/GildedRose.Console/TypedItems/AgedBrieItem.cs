using GildedRose.Console.TypedItems.Extensions;

namespace GildedRose.Console.TypedItems
{
    public class AgedBrieItem : ITypedItem
    {
        public AgedBrieItem(Item item) 
        {
            OriginalItem = item;
        }

        public Item OriginalItem { get; set; }

        public void UpdateQuality()
        {
            OriginalItem.Quality++;
            OriginalItem.SellIn--;
            OriginalItem.BoundQualityLimits();
        }
        public string Name { get => "Aged Brie"; }
    }
}
