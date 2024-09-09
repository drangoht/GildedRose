namespace GildedRose.Console.TypedItems
{
    public class SulfurasItem : ITypedItem
    {
        public SulfurasItem(Item item) 
        {
            OriginalItem = item;
        }
        public Item OriginalItem { get; set; }
        public void UpdateQuality()
        {
            // Nothing to do here, Sulfuras is unupdatable
        }
        public string Name { get => "Sulfuras, Hand of Ragnaros"; }
    }
}
