using ConsoleApp41.Enchants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp41.EnchantManagements
{
    class EnchantManagement : IEnchantManagement
    {
        private EnchantManagement(Dictionary<Enchant, int> enchantToLevelMap)
        {
            EnchantToLevelMap = enchantToLevelMap ?? throw new ArgumentNullException(nameof(enchantToLevelMap));
        }
        public EnchantManagement() : this(new Dictionary<Enchant, int>())
        {

        }
        private Dictionary<Enchant, int> EnchantToLevelMap { get; }
        public IEnumerator<KeyValuePair<Enchant, int>> GetEnumerator()
        {
            return EnchantToLevelMap.GetEnumerator();
        }

        public bool TryAddEnchant(Enchant enchant, int level)
        {
            //入力されたレベルが0以下の場合、false
            if (level < 0)
            {
                return false;
            }

            //入力されたレベルが最大レベルを超えた場合、false
            if (level > enchant.MaxLevel)
            {
                return false;
            }

            //新しくエンチャントを登録する場合、レベルをそのまま登録する
            if (!EnchantToLevelMap.ContainsKey(enchant))
            {
                EnchantToLevelMap[enchant] = level;
                return true;
            }

            //エンチャントレベルの合成
            int formerLevel = EnchantToLevelMap[enchant];
            int maxLevel = enchant.MaxLevel;
            int nextLevel;
            if (formerLevel != level)
            {
                //レベルが異なる場合は、より大きい値。
                nextLevel = Math.Max(formerLevel, level);
            }
            else
            {
                //レベルが等しい場合は、1大きい値。ただし、maxLevelは超えない。
                nextLevel = Math.Min(maxLevel, level + 1);
            }
            EnchantToLevelMap[enchant] = nextLevel;
            return true;
        }

        public bool TryGetLevel(Enchant enchant, out int level)
        {
            if (!EnchantToLevelMap.ContainsKey(enchant))
            {
                level = -1;
                return false;
            }
            else
            {
                level = EnchantToLevelMap[enchant];
                return true;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Clear()
        {
            //呪いの一覧を取得する
            var CurseDictionary = new Dictionary<Enchant, int>();
            foreach (var (enchant, level) in EnchantToLevelMap)
            {
                if (enchant.IsCurse)
                {
                    CurseDictionary.Add(enchant, level);
                }
            }

            //エンチャントをいったんすべて削除する
            EnchantToLevelMap.Clear();

            //呪いのみ追加する
            foreach (var (enchant, level) in CurseDictionary)
            {
                EnchantToLevelMap.Add(enchant, level);
            }
        }
        public override string ToString()
        {
            var enchantList = new List<string>();
            foreach (var (enchant, level) in EnchantToLevelMap)
            {
                enchantList.Add($"{enchant}{LevelStringMap[level]}");
            }
            return string.Join(", ", enchantList);
        }
        private static Dictionary<int, string> LevelStringMap { get; } = new Dictionary<int, string>()
        {
            [1] = "Ⅰ",
            [2] = "Ⅱ",
            [3] = "Ⅲ",
            [4] = "Ⅳ",
            [5] = "Ⅴ"
        };
    }
}
