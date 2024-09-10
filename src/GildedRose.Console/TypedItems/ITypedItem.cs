namespace GildedRose.Console.TypedItems
{
    public interface ITypedItem
    {
        public Item OriginalItem { get; set; }
        public void UpdateQuality();

        public string Name { get; }
    }
}
