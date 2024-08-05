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
        public void UpdateQualityShouldDecreaseQualityTwiceWhenSellInEqualTo0()
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
        public void UpdateQualityShouldKeepQualityTo0WhenQualityEqualTo0()
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
                SellIn = 10
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(1);
        }

        [Fact]
        // "Aged Brie" actually increases in Quality the older it gets when SellIn=0 (bug found !)
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsAgedBrieAndSellInEqualToZero()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 0
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
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 0
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(80);
        }

        [Fact]
        // "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        // value approaches;
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 12
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(1);
        }
        [Fact]
        // "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        // value approaches;
        // Quality increases by 2 when there are 10 days or less
        public void UpdateQualityShouldIncreaseQualityBy2WhenSellInLesserOrEqualTo10AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 10
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(2);
        }
        [Fact]
        // "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        // value approaches;
        // Quality increases by 2 when there are 10 days or less
        // and by 3 when there are 5 days
        public void UpdateQualityShouldIncreaseQualityBy3WhenSellInLesserrOrEqualTo5AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 5
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(3);
        }
        [Fact]
        // "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        // value approaches;
        // Quality increases by 2 when there are 10 days or less
        // and by 3 when there are 5 days or less but Quality drops to 0 after the
        // concert
        public void UpdateQualityShouldDropQualityTo0WhenSellInEqualTo0AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 0
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(0);
        }

        [Fact]
        // "Conjured" items degrade in Quality twice as fast as normal items
        public void UpdateQualityShouldDecreaseQualityTwiceWhenItemNameIsConjured()
        {
            Item item = new Item()
            {
                Name = "Conjured",
                Quality = 10,
                SellIn = 5
            };

            var app = new Program();
            var itemUpdated = app.UpddateQuality(item);

            Check.That(itemUpdated.Quality).IsEqualTo(8);
        }

    }
}