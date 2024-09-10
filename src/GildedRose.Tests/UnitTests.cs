using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Policy;
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace GildedRose.Tests
{
    public class UnitTests
    {
        [Fact]
        /// At the end of each day our system lowers both values for every item
        public void UpdateQualityShouldDecreaseQualityWithUnkownItem()
        {
            Item item = new Item()
            {
                Name = "+5 Dexterity Vest",
                Quality = 10,
                SellIn = 20
            };


            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);
            Assert.Equal(9, itemUpdated.Quality);
        }
        [Fact]
        /// At the end of each day our system lowers both values for every item
        public void UpdateQualityShouldDecreaseQuality()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 2,
                SellIn = 5
            };


            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);
            Assert.Equal(1, itemUpdated.Quality);
        }

        [Fact]
        /// Once the sell by date has passed, Quality degrades twice as fast
        public void UpdateQualityShouldDecreaseQualityTwiceWhenSellInEqualTo0()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 2,
                SellIn = 0
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);
            Assert.Equal(0, itemUpdated.Quality);
        }
        [Fact]
        /// The Quality of an item is never negative
        public void UpdateQualityShouldKeepQualityTo0WhenQualityEqualTo0()
        {
            Item item = new Item()
            {
                Name = "DefaultItem",
                Quality = 0,
                SellIn = 5
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);
            Assert.Equal(0, itemUpdated.Quality);
        }
        [Fact]
        /// "Aged Brie" actually increases in Quality the older it gets
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsAgedBrie()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 10
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(1, itemUpdated.Quality);
        }

        [Fact]
        /// "Aged Brie" actually increases in Quality the older it gets when SellIn=0 (bug found !)
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsAgedBrieAndSellInEqualToZero()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 0
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(1, itemUpdated.Quality);
        }
        [Fact]
        /// The Quality of an item is never more than 50
        public void UpdateQualityShouldNotIncreaseQualityOver50WhenQualityIsEquelTo50()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 5
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(50, itemUpdated.Quality);
        }


        [Fact]
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        public void UpdateQualityShouldChangeQualityOrSellInWhenItemNameIsSulfuras()
        {
            Item item = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 0
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(80, itemUpdated.Quality);
        }

        [Fact]
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches;
        public void UpdateQualityShouldIncreaseQualityWhenSellInDecreaseAndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 12
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(1, itemUpdated.Quality);
        }
        [Fact]
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        /// value approaches;
        /// Quality increases by 2 when there are 10 days or less
        public void UpdateQualityShouldIncreaseQualityBy2WhenSellInLesserOrEqualTo10AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 10
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(2, itemUpdated.Quality);
        }
        [Fact]
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        /// value approaches;
        /// Quality increases by 2 when there are 10 days or less
        /// and by 3 when there are 5 days
        public void UpdateQualityShouldIncreaseQualityBy3WhenSellInLesserrOrEqualTo5AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 5
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(3, itemUpdated.Quality);
        }
        [Fact]
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn 
        /// value approaches;
        /// Quality increases by 2 when there are 10 days or less
        /// and by 3 when there are 5 days or less but Quality drops to 0 after the
        /// concert
        public void UpdateQualityShouldDropQualityTo0WhenSellInEqualTo0AndItemNameIsBackstagePasses()
        {
            Item item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 0,
                SellIn = 0
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(0, itemUpdated.Quality);
        }

        [Fact]
        /// "Conjured" items degrade in Quality twice as fast as normal items
        public void UpdateQualityShouldDecreaseQualityTwiceWhenItemNameIsConjured()
        {
            Item item = new Item()
            {
                Name = "Conjured Mana Cake",
                Quality = 10,
                SellIn = 5
            };

            var app = new Console.Program();
            var itemUpdated = app.UpddateQuality(item);

            Assert.Equal(8, itemUpdated.Quality);
        }

    }
}