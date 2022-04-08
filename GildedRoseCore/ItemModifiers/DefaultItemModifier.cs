using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal class DefaultItemModifier : ItemModifier
    {
        public override bool IsDefaultModifier => true;
        public override bool ModifierMatchesItem(Item item)
            => true;
        public override void ModifyItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= IncrementValue;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= IncrementValue;
            }
        }
    }
}
