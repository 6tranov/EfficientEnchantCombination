using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp41.Enchants
{
    class Enchant
    {
        public Enchant(string name, int maxLevel, int costPerLevel, bool isCurse)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            MaxLevel = maxLevel;
            CostPerLevel = costPerLevel;
            IsCurse = isCurse;
        }

        public string Name { get; }
        public int MaxLevel { get; }
        public int CostPerLevel { get; }
        public bool IsCurse { get; }
        public override string ToString()
        {
            return Name;
        }
        #region Enchants

        //攻撃系のエンチャント
        /// <summary>
        /// ダメージ増加Ⅴ
        /// </summary>
        public static readonly Enchant Sharpness = new Enchant("ダメージ増加", 5, 1, false);
        /// <summary>
        /// 虫特効Ⅴ
        /// </summary>
        public static readonly Enchant BaneOfArthropode = new Enchant("虫特効", 5, 2, false);
        /// <summary>
        /// アンデッド特効Ⅴ
        /// </summary>
        public static readonly Enchant Smite = new Enchant("アンデッド特効", 5, 2, false);

        //剣のエンチャント
        /// <summary>
        /// ノックバックⅡ
        /// </summary>
        public static readonly Enchant Knockback = new Enchant("ノックバック", 2, 2, false);
        /// <summary>
        /// 火属性Ⅱ
        /// </summary>
        public static readonly Enchant FireAspect = new Enchant("火属性", 2, 4, false);
        /// <summary>
        /// ドロップ増加Ⅲ
        /// </summary>
        public static readonly Enchant Looting = new Enchant("ドロップ増加", 3, 4, false);
        /// <summary>
        /// 範囲ダメージ増加Ⅲ
        /// </summary>
        public static readonly Enchant SweepingEdge = new Enchant("範囲ダメージ増加", 3, 4, false);

        //トライデントのエンチャント
        /// <summary>
        /// 水生特効
        /// </summary>
        public static readonly Enchant Impaling = new Enchant("水生特攻", 5, 4, false);
        /// <summary>
        /// 激流Ⅲ
        /// </summary>
        public static readonly Enchant Riptide = new Enchant("激流", 3, 4, false);
        /// <summary>
        /// 忠誠Ⅲ
        /// </summary>
        public static readonly Enchant Loyalty = new Enchant("忠誠", 3, 1, false);
        /// <summary>
        /// 召雷
        /// </summary>
        public static readonly Enchant Channeling = new Enchant("召雷", 1, 8, false);

        //クロスボウのエンチャント
        /// <summary>
        /// 拡散
        /// </summary>
        public static readonly Enchant Multishot = new Enchant("拡散", 1, 4, false);
        /// <summary>
        /// 貫通Ⅳ
        /// </summary>
        public static readonly Enchant QuickCharge = new Enchant("貫通", 4, 1, false);
        /// <summary>
        /// 高速装填Ⅲ
        /// </summary>
        public static readonly Enchant Piercing = new Enchant("高速装填", 3, 2, false);

        //一般的なエンチャント
        /// <summary>
        /// 耐久力Ⅲ
        /// </summary>
        public static readonly Enchant Unbreaking = new Enchant("耐久力", 3, 2, false);
        /// <summary>
        /// 修繕
        /// </summary>
        public static readonly Enchant Mending = new Enchant("修繕", 1, 4, false);

        //ツールのエンチャント
        /// <summary>
        /// 効率強化Ⅴ
        /// </summary>
        public static readonly Enchant Efficiency = new Enchant("効率強化", 5, 1, false);
        /// <summary>
        /// 幸運Ⅲ
        /// </summary>
        public static readonly Enchant Fortune = new Enchant("幸運", 3, 4, false);
        /// <summary>
        /// シルクタッチ
        /// </summary>
        public static readonly Enchant SilkTouch = new Enchant("シルクタッチ", 1, 8, false);

        //釣り竿のエンチャント
        /// <summary>
        /// 宝釣りⅢ
        /// </summary>
        public static readonly Enchant LuckOfTheSea = new Enchant("宝釣り", 3, 4, false);
        /// <summary>
        /// 入れ食いⅢ
        /// </summary>
        public static readonly Enchant Lure = new Enchant("入れ食い", 3, 4, false);

        //防具のエンチャント
        /// <summary>
        /// ダメージ軽減Ⅳ
        /// </summary>
        public static readonly Enchant Protection = new Enchant("ダメージ軽減", 4, 2, false);
        /// <summary>
        /// 火炎耐性Ⅳ
        /// </summary>
        public static readonly Enchant FireProtection = new Enchant("火炎耐性", 4, 2, false);
        /// <summary>
        /// 飛び道具耐性Ⅳ
        /// </summary>
        public static readonly Enchant ProjectileProtection = new Enchant("飛び道具耐性", 4, 2, false);
        /// <summary>
        /// 爆発耐性Ⅳ
        /// </summary>
        public static readonly Enchant BlastProtection = new Enchant("爆発耐性", 4, 4, false);
        /// <summary>
        /// 棘の鎧Ⅲ
        /// </summary>
        public static readonly Enchant Thorns = new Enchant("棘の鎧", 3, 8, false);

        //ヘルメットのエンチャント
        /// <summary>
        /// 水中呼吸Ⅲ
        /// </summary>
        public static readonly Enchant Respiration = new Enchant("水中呼吸", 3, 4, false);
        /// <summary>
        /// 水中採掘
        /// </summary>
        public static readonly Enchant AquaAffinity = new Enchant("水中採掘", 1, 4, false);

        //ブーツのエンチャント
        /// <summary>
        /// 落下耐性Ⅳ
        /// </summary>
        public static readonly Enchant FeatherFalling = new Enchant("落下耐性", 4, 2, false);
        /// <summary>
        /// 水中歩行Ⅲ
        /// </summary>
        public static readonly Enchant DepthStrider = new Enchant("水中歩行", 3, 4, false);
        /// <summary>
        /// ソウルスピードⅢ
        /// </summary>
        public static readonly Enchant SoulSpeed = new Enchant("ソウルスピード", 3, 8, false);
        /// <summary>
        /// 氷渡りⅡ
        /// </summary>
        public static readonly Enchant FrostWalder = new Enchant("氷渡り", 2, 4, false);

        //弓のエンチャント
        /// <summary>
        /// 射撃ダメージ増加Ⅴ
        /// </summary>
        public static readonly Enchant Power = new Enchant("射撃ダメージ増加", 5, 1, false);
        /// <summary>
        /// パンチⅡ
        /// </summary>
        public static readonly Enchant Punch = new Enchant("パンチ", 2, 4, false);
        /// <summary>
        /// フレイム
        /// </summary>
        public static readonly Enchant Flame = new Enchant("フレイム", 1, 4, false);
        /// <summary>
        /// 無限
        /// </summary>
        public static readonly Enchant Infinity = new Enchant("無限", 1, 8, false);
        #endregion
    }
}
