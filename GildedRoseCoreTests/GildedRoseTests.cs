using GildedRoseCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string CONJURED = "Conjured";
        private const string SULFORAS = "Sulfuras, Hand of Ragnaros";
        private const string ELIXIR = "Elixir of the Mongoose";
        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";

        [Fact]
        public void AgedBrieCannotExceed50Quality()
        {
            GildedRoseCore.GildedRose rose = new ();
            int ii = 0;
            while (ii++ < 100)
            {
                rose.UpdateQuality();
            }

            Assert.True(rose.Items.First(x => x.Name.Equals(AGED_BRIE, StringComparison.OrdinalIgnoreCase)).Quality <= 50);
        }

        [Fact]
        public void ConjuredItemsDegradeTwiceAsQuickly()
        { 
            GildedRoseCore.GildedRose rose = new();

            rose.UpdateQuality();

            Assert.True(rose.Items.First(x => x.Name.StartsWith(CONJURED, StringComparison.OrdinalIgnoreCase)).Quality == 4);
        }

        [Fact]
        public void QualityCanNeverGoNegative()
        {
            GildedRoseCore.GildedRose rose = new();
            int ii = 0;
            while (ii++ < 100)
            {
                rose.UpdateQuality();
            }

            Assert.True(rose.Items.All(x => x.Quality >= 0));
        }

        [Fact]
        public void LegendaryItemMaintainsQualityAndHasNoSellIn()
        {
            GildedRoseCore.GildedRose rose = new();
            int ii = 0;
            while (ii++ < 100)
            {
                rose.UpdateQuality();
            }
            Item item = rose.Items.First(x => x.Name.StartsWith(SULFORAS, StringComparison.OrdinalIgnoreCase));
            Assert.True(item.Quality == 80);
            Assert.True(item.SellIn == 0);
        }

        [Fact]
        public void QualityReducesAtTheCorrectRate()
        {
            GildedRoseCore.GildedRose rose = new();
            int ii = 0;
            while (ii++ < 5)
            {
                rose.UpdateQuality();
            }
            Item item = rose.Items.First(x => x.Name.StartsWith(ELIXIR, StringComparison.OrdinalIgnoreCase));
            Assert.True(item.Quality == 2);
            Assert.True(item.SellIn == 0);

            rose.UpdateQuality();
            Assert.True(item.Quality == 0);
        }

        [Fact]
        public void BackstagePassQualityIncreasesCorrectly()
        {
            GildedRoseCore.GildedRose rose = new();
            Item item = rose.Items.First(x => x.Name.Equals(BACKSTAGE_PASS, StringComparison.OrdinalIgnoreCase));
            while (item.SellIn > 10)
            {
                rose.UpdateQuality();
            }
            Assert.True(item.Quality == 25);
            Assert.True(item.SellIn == 10);

            while (item.SellIn > 5)
            {
                rose.UpdateQuality();
            }
            Assert.True(item.Quality == 35);
            Assert.True(item.SellIn == 5);

            while (item.SellIn > 0)
            {
                rose.UpdateQuality();
            }
            Assert.True(item.Quality == 50);
            Assert.True(item.SellIn == 0);

            rose.UpdateQuality();
            Assert.True(item.Quality == 0);
        }
    }
}