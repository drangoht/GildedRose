using GildedRose.Console.TypedItems.Extensions;

namespace GildedRose.Console.TypedItems
{
    public class BackstagePassesItem : ITypedItem
    {
        public BackstagePassesItem(Item item) 
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public void UpdateQuality()
        {

            if (OriginalItem.SellIn <= 0)
            {
                OriginalItem.Quality = 0;
                return;
            }
            if (OriginalItem.SellIn < 6)
            {
                OriginalItem.Quality += 3;
                OriginalItem.SellIn--;
                OriginalItem.BoundQualityLimits();
                return;
            }
            if (OriginalItem.SellIn < 11)
            {
                OriginalItem.Quality += 2;
                OriginalItem.SellIn--;
                OriginalItem.BoundQualityLimits();
                return;
            }
            OriginalItem.Quality++;
            OriginalItem.SellIn--;
            OriginalItem.BoundQualityLimits();
            
        }

        public string Name { get => "Backstage passes to a TAFKAL80ETC concert"; }
}
}
