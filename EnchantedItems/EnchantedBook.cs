using ConsoleApp41.EnchantManagements;
using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp41.Enchants.Enchant;

namespace ConsoleApp41.EnchantedItems
{
    class EnchantedBook : AbstractEnchantedItem
    {
        #region public
        public EnchantedBook(int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount) : base(totalCost, totalMinEXP, enchantManagement, combinedCount)
        {
        }

        protected EnchantedBook(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount) : base(name, totalCost, totalMinEXP, enchantManagement, combinedCount)
        {
        }
        #endregion
        #region protected

        /// <summary>
        /// 本のベースコストは半分+余り
        /// </summary>
        protected override int BaseCost
        {
            get
            {
                var baseCost = base.BaseCost;
                return baseCost / 2 + baseCost % 2;
            }
        }
        protected override bool CanCombineAsItem(AbstractEnchantedItem enchantedItem)
        {
            return enchantedItem is EnchantedBook;
        }

        protected override AbstractEnchantedItem GetCombinedItem(string name, int totalCost, int totalMinEXP, IEnchantManagement enchantManagement, int combinedCount)
        {
            return new EnchantedBook(name, totalCost, totalMinEXP, enchantManagement, combinedCount);
        }
        #endregion
        private static EnchantedBook CreateNewBook(Enchants.Enchant enchant)
        {
            var enchantManagement = new EnchantManagement();
            enchantManagement.TryAddEnchant(enchant, enchant.MaxLevel);
            return new EnchantedBook(0, 0, enchantManagement, 0);
        }
        #region public static EnchantedBooks
        //攻撃系のエンチャント
        /// <summary>
        /// ダメージ増加Ⅴ
        /// </summary>
        public static EnchantedBook Sharpness5Book { get; } = CreateNewBook(Sharpness);
        /// <summary>
        /// 虫特効Ⅴ
        /// </summary>
        public static EnchantedBook BaneOfArthropode5Book { get; } = CreateNewBook(BaneOfArthropode);
        /// <summary>
        /// アンデッド特効Ⅴ
        /// </summary>
        public static EnchantedBook Smite5Book { get; } = CreateNewBook(Smite);

        //剣のエンチャント
        /// <summary>
        /// ノックバックⅡ
        /// </summary>
        public static EnchantedBook Knockback2Book { get; } = CreateNewBook(Knockback);
        /// <summary>
        /// 火属性Ⅱ
        /// </summary>
        public static EnchantedBook FireAspect2Book { get; } = CreateNewBook(FireAspect);
        /// <summary>
        /// ドロップ増加Ⅲ
        /// </summary>
        public static EnchantedBook Looting3Book { get; } = CreateNewBook(Looting);
        /// <summary>
        /// 範囲ダメージ増加Ⅲ
        /// </summary>
        public static EnchantedBook SweepingEdge3Book { get; } = CreateNewBook(SweepingEdge);

        //トライデントのエンチャント
        /// <summary>
        /// 水生特効
        /// </summary>
        public static EnchantedBook ImpalingBook { get; } = CreateNewBook(Impaling);
        /// <summary>
        /// 激流Ⅲ
        /// </summary>
        public static EnchantedBook Riptide3Book { get; } = CreateNewBook(Riptide);
        /// <summary>
        /// 忠誠Ⅲ
        /// </summary>
        public static EnchantedBook Loyalty3Book { get; } = CreateNewBook(Loyalty);
        /// <summary>
        /// 召雷
        /// </summary>
        public static EnchantedBook ChannelingBook { get; } = CreateNewBook(Channeling);

        //クロスボウのエンチャント
        /// <summary>
        /// 拡散
        /// </summary>
        public static EnchantedBook MultishotBook { get; } = CreateNewBook(Multishot);
        /// <summary>
        /// 貫通Ⅳ
        /// </summary>
        public static EnchantedBook QuickCharge4Book { get; } = CreateNewBook(QuickCharge);
        /// <summary>
        /// 高速装填Ⅲ
        /// </summary>
        public static EnchantedBook Piercing3Book { get; } = CreateNewBook(Piercing);

        //一般的なエンチャント
        /// <summary>
        /// 耐久力Ⅲ
        /// </summary>
        public static EnchantedBook Unbreaking3Book { get; } = CreateNewBook(Unbreaking);
        /// <summary>
        /// 修繕
        /// </summary>
        public static EnchantedBook MendingBook { get; } = CreateNewBook(Mending);

        //ツールのエンチャント
        /// <summary>
        /// 効率強化Ⅴ
        /// </summary>
        public static EnchantedBook Efficiency5Book { get; } = CreateNewBook(Efficiency);
        /// <summary>
        /// 幸運Ⅲ
        /// </summary>
        public static EnchantedBook Fortune3Book { get; } = CreateNewBook(Fortune);
        /// <summary>
        /// シルクタッチ
        /// </summary>
        public static EnchantedBook SilkTouchBook { get; } = CreateNewBook(SilkTouch);

        //釣り竿のエンチャント
        /// <summary>
        /// 宝釣りⅢ
        /// </summary>
        public static EnchantedBook LuckOfTheSea3Book { get; } = CreateNewBook(LuckOfTheSea);
        /// <summary>
        /// 入れ食いⅢ
        /// </summary>
        public static EnchantedBook Lure3Book { get; } = CreateNewBook(Lure);

        //防具のエンチャント
        /// <summary>
        /// ダメージ軽減Ⅳ
        /// </summary>
        public static EnchantedBook Protection4Book { get; } = CreateNewBook(Protection);
        /// <summary>
        /// 火炎耐性Ⅳ
        /// </summary>
        public static EnchantedBook FireProtection4Book { get; } = CreateNewBook(FireProtection);
        /// <summary>
        /// 飛び道具耐性Ⅳ
        /// </summary>
        public static EnchantedBook ProjectileProtection4Book { get; } = CreateNewBook(ProjectileProtection);
        /// <summary>
        /// 爆発耐性Ⅳ
        /// </summary>
        public static EnchantedBook BlastProtection4Book { get; } = CreateNewBook(BlastProtection);
        /// <summary>
        /// 棘の鎧Ⅲ
        /// </summary>
        public static EnchantedBook Thorns3Book { get; } = CreateNewBook(Thorns);

        //ヘルメットのエンチャント
        /// <summary>
        /// 水中呼吸Ⅲ
        /// </summary>
        public static EnchantedBook Respiration3Book { get; } = CreateNewBook(Respiration);
        /// <summary>
        /// 水中採掘
        /// </summary>
        public static EnchantedBook AquaAffinityBook { get; } = CreateNewBook(AquaAffinity);

        //ブーツのエンチャント
        /// <summary>
        /// 落下耐性Ⅳ
        /// </summary>
        public static EnchantedBook FeatherFalling4Book { get; } = CreateNewBook(FeatherFalling);
        /// <summary>
        /// 水中歩行Ⅲ
        /// </summary>
        public static EnchantedBook DepthStrider3Book { get; } = CreateNewBook(DepthStrider);
        /// <summary>
        /// ソウルスピードⅢ
        /// </summary>
        public static EnchantedBook SoulSpeed3Book { get; } = CreateNewBook(SoulSpeed);
        /// <summary>
        /// 氷渡りⅡ
        /// </summary>
        public static EnchantedBook FrostWalder2Book { get; } = CreateNewBook(FrostWalder);

        //弓のエンチャント
        /// <summary>
        /// 射撃ダメージ増加Ⅴ
        /// </summary>
        public static EnchantedBook Power5Book { get; } = CreateNewBook(Power);
        /// <summary>
        /// パンチⅡ
        /// </summary>
        public static EnchantedBook Punch2Book { get; } = CreateNewBook(Punch);
        /// <summary>
        /// フレイム
        /// </summary>
        public static EnchantedBook FlameBook { get; } = CreateNewBook(Flame);
        /// <summary>
        /// 無限
        /// </summary>
        public static EnchantedBook InfinityBook { get; } = CreateNewBook(Infinity);
        #endregion
    }
}
