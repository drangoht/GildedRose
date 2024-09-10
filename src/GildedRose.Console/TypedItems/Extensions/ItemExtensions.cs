namespace GildedRose.Console.TypedItems.Extensions
{
    public static class ItemExtensions
    {
        public static void BoundQualityLimits(this Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
                return;
            }
            if (item.Quality > 50)
            {
                item.Quality = 50;
                return;
            }
        }
    }
}
