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
            {
                OriginalItem.Quality = 0;
                return;
            }
            if (OriginalItem.Quality > 50)
            {
                OriginalItem.Quality = 50;
                return;
            }
        }
        public virtual string Name {  get=> string.Empty; }
    }
}
