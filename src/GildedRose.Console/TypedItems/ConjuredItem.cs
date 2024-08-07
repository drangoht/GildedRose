namespace GildedRose.Console.TypedItems
{
    public class ConjuredItem : TypedItem
    {
        public ConjuredItem(Item item) : base(item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public override void UpdateQuality()
        {
            OriginalItem.Quality -= 2;
            OriginalItem.SellIn--;
            base.UpdateQuality();
        }
    }
}
