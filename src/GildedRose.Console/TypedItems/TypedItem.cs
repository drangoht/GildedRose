namespace GildedRose.Console.TypedItems
{
    public abstract class TypedItem
    {
        Item OriginalItem { get; set; }
        protected TypedItem(Item item)
        {
            OriginalItem = item;
        }
        public virtual void UpdateQuality()
        {

            if (OriginalItem.Quality < 0)
                OriginalItem.Quality = 0;

            if (OriginalItem.Quality > 50)
                OriginalItem.Quality = 50;
        }
    }
}
