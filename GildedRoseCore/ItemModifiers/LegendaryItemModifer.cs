using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal class LegendaryItemModifier : ItemModifier
    {
        public override bool ModifierMatchesItem(Item item)
            => item.Name.StartsWith("Sulfuras", StringComparison.OrdinalIgnoreCase);

    }
}
