using ConsoleApp41.EnchantManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp41.EnchantedItems
{
    class EnchantedBoots : AbstractEnchantedItem
    {
        public EnchantedBoots(int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount) : base(totalCost, totalMinEXP, enchantManagement, combinedCount)
        {
        }

        protected EnchantedBoots(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount) : base(name, totalCost, totalMinEXP, enchantManagement, combinedCount)
        {
        }

        protected override bool CanCombineAsItem(AbstractEnchantedItem enchantedItem)
        {
            return enchantedItem is EnchantedBook ||
                enchantedItem is EnchantedBoots;
        }

        protected override AbstractEnchantedItem GetCombinedItem(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount)
        {
            return new EnchantedBoots(name, totalCost, totalMinEXP, enchantManagement, combinedCount);
        }

        public static EnchantedBoots Boots { get; } = new EnchantedBoots("ブーツ", 0, 0, new EnchantManagement(), 0);
    }
}
