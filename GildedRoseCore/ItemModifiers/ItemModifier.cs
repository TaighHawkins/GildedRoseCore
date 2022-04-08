using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal abstract class ItemModifier : IItemModifier
    {
        public virtual bool IsDefaultModifier => false;
        public void ModifyIncrementIfConjured(Item item)
        {
            if (item.Name.StartsWith("Conjured", StringComparison.OrdinalIgnoreCase))
            {
                IncrementValue = 2;
            }
        }
        internal int IncrementValue = 1;

        public abstract bool ModifierMatchesItem(Item name);

        public virtual void ModifyItem(Item item) { }
    }
}
