using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp41.Enchants;

namespace ConsoleApp41.EnchantManagements
{
    interface IEnchantManagement : IEnumerable<KeyValuePair<Enchant, int>>
    {
        bool TryAddEnchant(Enchant enchant, int level);
        bool TryGetLevel(Enchant enchant, out int level);
        void Clear();
    }
}
