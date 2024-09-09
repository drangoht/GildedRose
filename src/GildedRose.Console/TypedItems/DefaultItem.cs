namespace GildedRose.Console.TypedItems
{
    public class DefaultItem : TypedItem
    {
        public DefaultItem(Item item) : base(item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }

        public override void UpdateQuality()
        {
            if (OriginalItem.SellIn == 0)
            {
                OriginalItem.Quality--;
            }
            OriginalItem.Quality--;
            OriginalItem.SellIn--;
            base.UpdateQuality();
        }
        public override string Name { get => "DefaultItem"; }
    }
}
