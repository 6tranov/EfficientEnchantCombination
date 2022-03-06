using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp41.EnchantManagements;

namespace ConsoleApp41.EnchantedItems
{
    abstract class AbstractEnchantedItem
    {
        #region Constructers
        protected AbstractEnchantedItem(int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount)
        {
            TotalCost = totalCost;
            TotalMinEXP = totalMinEXP;
            EnchantManagement = enchantManagement ?? throw new ArgumentNullException(nameof(enchantManagement));
            CombinedCount = combinedCount;
            Name = EnchantManagement.ToString();
        }

        protected AbstractEnchantedItem(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TotalCost = totalCost;
            TotalMinEXP = totalMinEXP;
            EnchantManagement = enchantManagement ?? throw new ArgumentNullException(nameof(enchantManagement));
            CombinedCount = combinedCount;
        }
        #endregion
        #region public
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// このアイテムを合成するために必要な累計コスト
        /// </summary>
        public int TotalCost { get; }
        /// <summary>
        /// このアイテムを合成するために必要な累計経験値
        /// </summary>
        public int TotalMinEXP { get; }
        /// <summary>
        /// アイテムの合成
        /// </summary>
        /// <param name="right">金床で右側に来るアイテム</param>
        /// <param name="combinedEnchantedItem">合成後のアイテム</param>
        /// <returns></returns>
        public bool TryCombine(AbstractEnchantedItem right, out AbstractEnchantedItem combinedEnchantedItem)
        {
            //合成できない場合はfalse。
            if (!CanCombine(right))
            {
                combinedEnchantedItem = null;
                return false;
            }

            //outで返すインスタンスのパラメータの作成
            //name
            var (p1, p2) = GetParentheses;
            var (p3, p4) = right.GetParentheses;
            var name = $"{p1}{Name}{p2}+{p3}{right.Name}{p4}";
            //totalCost
            var combineCost = right.BaseCost + AdditionalCost + right.AdditionalCost;
            var totalCost = TotalCost + right.TotalCost + combineCost;
            //totalMinEXP
            var combineEXP = CostToEXP(combineCost);
            var totalMinEXP = TotalMinEXP + right.TotalMinEXP + combineEXP;
            //enchantManagement
            var enchantManagement = new EnchantManagement();
            foreach (var (enchant, level) in EnchantManagement)
            {
                if (!enchantManagement.TryAddEnchant(enchant, level))
                {
                    combinedEnchantedItem = null;
                    return false;
                }
            }
            foreach (var (enchant, level) in right.EnchantManagement)
            {
                if (!enchantManagement.TryAddEnchant(enchant, level))
                {
                    combinedEnchantedItem = null;
                    return false;
                }
            }
            //combinedCount
            var combinedCount = Math.Max(CombinedCount, right.CombinedCount) + 1;

            combinedEnchantedItem = GetCombinedItem(name, totalCost, totalMinEXP, enchantManagement, combinedCount);
            return true;

            static int CostToEXP(int cost)
            {
                if (cost < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(cost));
                }
                else if (cost <= 16)
                {
                    return cost * cost + 6 * cost;
                }
                else if (cost <= 31)
                {
                    return (5 * cost * cost - 81 * cost) / 2 + 360;
                }
                else
                {
                    return (9 * cost * cost - 325 * cost) / 2 + 2220;
                }
            }
        }
        #endregion
        #region protected
        /// <summary>
        /// 合成できるかどうか
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        protected virtual bool CanCombine(AbstractEnchantedItem right)
        {
            return CanCombineAsItem(right) && CanCombineAsEnchant(right.EnchantManagement);
        }
        /// <summary>
        /// エンチャント管理
        /// </summary>
        protected IEnchantManagement EnchantManagement { get; }
        /// <summary>
        /// 合成できるアイテムの組み合わせかどうか。
        /// </summary>
        /// <param name="enchantedItem"></param>
        /// <returns></returns>
        protected abstract bool CanCombineAsItem(AbstractEnchantedItem enchantedItem);
        /// <summary>
        /// 合成できるエンチャントかどうか。
        /// </summary>
        /// <param name="enchantedItem"></param>
        /// <returns></returns>
        protected virtual bool CanCombineAsEnchant(IEnchantManagement enchantManagement)
        {
            /*
             * 競合のメモ
             * ダメージ増加・アンデッド特効・虫特効
             * 忠誠・激流
             * 激流・召雷
             * 拡散・貫通
             * 無限・修繕
             * シルクタッチ・幸運
             * ダメージ軽減・火炎耐性・爆発耐性・飛び道具耐性
             * 水中歩行・氷渡り
             * 
             */
            return true;//後で実装する
        }
        /// <summary>
        /// エンチャントから計算されるベースコスト
        /// </summary>
        protected virtual int BaseCost
        {
            get
            {
                var result = 0;
                foreach (var (enchant, level) in EnchantManagement)
                {
                    result += enchant.CostPerLevel * level;
                }
                return result;
            }
        }
        /// <summary>
        /// 合成後のアイテム
        /// </summary>
        /// <param name="name"></param>
        /// <param name="totalCost"></param>
        /// <param name="totalMinEXP"></param>
        /// <param name="enchantManagement"></param>
        /// <returns></returns>
        protected abstract AbstractEnchantedItem GetCombinedItem(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount);
        #endregion
        #region private
        /// <summary>
        /// 合成回数から計算される追加コスト
        /// </summary>
        private int AdditionalCost
        {
            get
            {
                switch (CombinedCount)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                    case 2:
                        return 3;
                    case 3:
                        return 7;
                    case 4:
                        return 15;
                    case 5:
                        return 31;
                    default:
                        var result = 1;
                        for (int i = 0; i < CombinedCount; i++)
                        {
                            result *= 2;
                        }
                        return result - 1;
                }
            }
        }
        /// <summary>
        /// 合成回数から括弧への写像
        /// </summary>
        private (string leftParen, string rightParen) GetParentheses
        {
            get
            {
                return CombinedCount switch
                {
                    0 => ("", ""),
                    1 => ("(", ")"),
                    2 => ("{", "}"),
                    3 => ("[", "]"),
                    4 => ("<", ">"),
                    _ => ("(", ")"),
                };
            }
        }
        /// <summary>
        /// 累計合成回数
        /// </summary>
        public int CombinedCount { get; }
        #endregion
        public bool HasBiggerBaseCostThan(AbstractEnchantedItem right)
        {
            return BaseCost > right.BaseCost;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is AbstractEnchantedItem item &&
                Name == item.Name;
        }
    }
}
