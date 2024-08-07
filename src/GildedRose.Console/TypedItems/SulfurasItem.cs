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
            // Nothing to do here, Sulfuras is unupdatable
        }
    }
}
