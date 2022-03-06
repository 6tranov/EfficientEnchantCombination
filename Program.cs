using System;
using System.Collections.Generic;
using ConsoleApp41.EnchantedItems;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            var enchantCandidates = new EnchantCandidates.EnchantCandidates();
            var em = new EnchantManagements.EnchantManagement();
            em.TryAddEnchant(Enchants.Enchant.SoulSpeed, 1);
            var soulSpeed1Book = new EnchantedBook(0, 0, em, 0);
            enchantCandidates.AddEnchantedItem(EnchantedBoots.Boots);
            enchantCandidates.AddEnchantedItem(EnchantedBook.Unbreaking3Book);
            enchantCandidates.AddEnchantedItem(EnchantedBook.MendingBook);
            enchantCandidates.AddEnchantedItem(EnchantedBook.Protection4Book);
            enchantCandidates.AddEnchantedItem(EnchantedBook.Thorns3Book);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.SoulSpeed3Book);
            enchantCandidates.AddEnchantedItem(soulSpeed1Book);
            enchantCandidates.AddEnchantedItem(soulSpeed1Book);
            enchantCandidates.AddEnchantedItem(soulSpeed1Book);
            enchantCandidates.AddEnchantedItem(soulSpeed1Book);
            enchantCandidates.AddEnchantedItem(EnchantedBook.FeatherFalling4Book);
            enchantCandidates.AddEnchantedItem(EnchantedBook.DepthStrider3Book);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.Unbreaking3Book);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.SilkTouchBook);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.Efficiency5Book);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.MendingBook);
            //enchantCandidates.AddEnchantedItem(EnchantedBook.Sharpness5Book);
            enchantCandidates.TryGetMinResult(out IEnumerable<AbstractEnchantedItem> result);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}:コスト{item.TotalCost},合成回数{item.CombinedCount}回");
            }
        }
    }
}
