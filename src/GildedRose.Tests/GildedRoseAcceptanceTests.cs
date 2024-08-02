using Xunit;
using NFluent;
using NFluent.Extensions;
using GildedRose.Console;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Policy;
namespace GildedRose.Tests
{
    public class GildedRoseAcceptanceTests
    {
        [Fact]
        // At the end of each day our system lowers both values for every item
        public void UpdateQualityShouldDecreaseQuality()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 2,
                SellIn = 5
            };
            

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(1);
        }

        [Fact]
        // Once the sell by date has passed, Quality degrades twice as fast
        public void UpdateQualityShouldDecreaseQualityTwiceWhenSellInEqualZero()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 2,
                SellIn = 0
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(0);
        }
        [Fact]
        // The Quality of an item is never negative
        public void UpdateQualityShouldKeepQualityToZeroWhenQualityEqualToZero()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 0,
                SellIn = 5
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(0);
        }
        [Fact]
        // "Aged Brie" actually increases in Quality the older it gets
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsAgedBrie()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 5
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(1);
        }
        [Fact]
        // The Quality of an item is never more than 50
        public void UpdateQualityShouldNotIncreaseQualityOver50WhenQualityIsEquelTo50()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 5
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(50);
        }
        
        
                    [Fact]
        // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        public void UpdateQualityShouldChangeQualityOrSellInWhenItemNameIsSulfuras()
        {
            Item item = new Item()
            {
                Name = "Sulfuras",
                Quality = 80,
                SellIn = 0
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(80);
        }
    }
}