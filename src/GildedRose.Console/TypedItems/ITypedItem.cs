namespace GildedRose.Console.TypedItems
{
    public interface ITypedItem
    {
        public void UpdateQuality();

        public string Name {  get; }
    }
}
