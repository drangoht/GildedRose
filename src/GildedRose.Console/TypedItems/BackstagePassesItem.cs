namespace GildedRose.Console.TypedItems
{
    public class BackstagePassesItem : TypedItem
    {
        public BackstagePassesItem(Item item) : base(item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public override void UpdateQuality()
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
                base.UpdateQuality();
                return;
            }
            if (OriginalItem.SellIn < 11)
            {
                OriginalItem.Quality += 2;
                OriginalItem.SellIn--;
                base.UpdateQuality();
                return;
            }
            OriginalItem.Quality++;
            OriginalItem.SellIn--;
            base.UpdateQuality();
        }
        public override string Name { get => "Backstage passes to a TAFKAL80ETC concert";}
}
}
