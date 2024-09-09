using GildedRose.Console.TypedItems.Extensions;

namespace GildedRose.Console.TypedItems
{
    public class DefaultItem : ITypedItem
    {
        public DefaultItem(Item item) 
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public void UpdateQuality()
        {
            if (OriginalItem.SellIn == 0)
            {
                OriginalItem.Quality--;
            }
            OriginalItem.Quality--;
            OriginalItem.SellIn--;
            OriginalItem.BoundQualityLimits();
        }
        public string Name { get => "DefaultItem"; }
    }
}
