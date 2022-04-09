using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseCore.ItemModifiers
{
    internal interface IItemModifier
    {
        bool ModifierMatchesItem(Item item);
        void ModifyIncrementIfConjured(Item item);
        public void ModifyItem(Item item);
    }
}
