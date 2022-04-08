using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal class AgedBrieModifier : ItemModifier
    {
        public override bool ModifierMatchesItem(Item item)
            => item.Name.Contains("Aged Brie", StringComparison.OrdinalIgnoreCase);
        public override void ModifyItem(Item item)
        {
            if (item.Quality < 50 - IncrementValue)
            {
                item.Quality += IncrementValue;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < 50 - IncrementValue)
            {
                item.Quality += IncrementValue;
            }
        }
    }
}
