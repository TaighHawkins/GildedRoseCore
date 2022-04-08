using GildedRoseCore.ItemModifiers;
using System.Collections.Generic;

namespace GildedRoseCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");
            GildedRose rose = new ();
            rose.UpdateQuality();
            Console.ReadKey();
        }
    }
    
    public class GildedRose { 

        public IList<Item> Items { get; set; }

        public GildedRose()
        {
            Items = GetDefaultItems();
        }
        public GildedRose(IList<Item> items)
        {
            if (items.Any())
            {
                Items = items;
            }
            else
            {
                Items = GetDefaultItems();
            }
        }

        private static IList<Item> GetDefaultItems() 
            => new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IItemModifier modifier = ModifierFactory.GetItemModifier(item);
                modifier.ModifyIncrementIfConjured(item);
                modifier.ModifyItem(item);
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
