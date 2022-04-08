using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal class ModifierFactory
    {
        private static List<IItemModifier> _modifiers
            => new()
            {
                new AgedBrieModifier(),
                new BackstagePassModifier(),
                new LegendaryItemModifier()
            };

        private static IItemModifier _default
            => new DefaultItemModifier();

        public static IItemModifier GetItemModifier(Item item)
        {
            return _modifiers.FirstOrDefault(x => x.ModifierMatchesItem(item)) ?? _default;
        }
    }
}
