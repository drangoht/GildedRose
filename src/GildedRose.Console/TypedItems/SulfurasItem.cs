namespace GildedRose.Console.TypedItems
{
    public class SulfurasItem : TypedItem
    {
        public SulfurasItem(Item item) : base(item)
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }
        public override void UpdateQuality()
        {
            // Nothing to do here, Sulfuras is unupdatable
        }
        public override string Name { get => "Sulfuras, Hand of Ragnaros"; }
    }
}
