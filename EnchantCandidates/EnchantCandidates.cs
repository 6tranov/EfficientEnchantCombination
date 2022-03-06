using ConsoleApp41.EnchantedItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp41.EnchantCandidates
{
    class EnchantCandidates
    {
        #region Constructers
        public EnchantCandidates(List<AbstractEnchantedItem> itemList)
        {
            ItemList = itemList ?? throw new ArgumentNullException(nameof(itemList));
        }

        public EnchantCandidates() : this(new List<AbstractEnchantedItem>())
        {
        }
        #endregion
        #region Private properties
        private List<AbstractEnchantedItem> ItemList { get; }
        private int Count { get { return ItemList.Count; } }
        #endregion
        #region Public methods
        public void AddEnchantedItem(AbstractEnchantedItem enchantedItem)
        {

            ItemList.Add(enchantedItem);
        }
        #endregion
        #region Private methods
        private AbstractEnchantedItem this[int index]
        {
            get
            {
                return ItemList[index];
            }
        }
        #endregion
        private IEnumerable<EnchantCandidates> GetNexts()
        {
            var result = new List<EnchantCandidates>();
            for (int i = 1; i < this.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var itemi = this[i];
                    var itemj = this[j];
                    if (itemi.HasBiggerBaseCostThan(itemj))
                    {
                        //iが左、jが右として合成
                        if (itemi.TryCombine(itemj, out AbstractEnchantedItem combinedItem))
                        {
                            result.Add(GetEnchantCandidates(i, j, combinedItem));
                        }
                        else
                        {
                            //失敗した場合は左右反対で試す
                            if (itemj.TryCombine(itemi, out combinedItem))
                            {
                                result.Add(GetEnchantCandidates(i, j, combinedItem));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        //jが左、iが右として合成
                        if (itemj.TryCombine(itemi, out AbstractEnchantedItem combinedItem))
                        {
                            result.Add(GetEnchantCandidates(i, j, combinedItem));
                        }
                        else
                        {
                            //失敗した場合は左右反対で試す
                            if (itemi.TryCombine(itemj, out combinedItem))
                            {
                                result.Add(GetEnchantCandidates(i, j, combinedItem));
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            return result;

            EnchantCandidates GetEnchantCandidates(int i, int j, AbstractEnchantedItem combinedItem)
            {
                var ec = new EnchantCandidates();
                ec.AddEnchantedItem(combinedItem);
                for (int k = 0; k < this.Count; k++)
                {
                    if (k != i && k != j)
                    {
                        ec.AddEnchantedItem(this[k]);
                    }
                }
                return ec;
            }
        }
        private bool TryGetResult(out IEnumerable<AbstractEnchantedItem> result)
        {
            //候補が1つになるまで分割する
            var tmp1 = new List<EnchantCandidates>() { this };
            for (int i = 0; i < Count - 1; i++)
            {
                tmp1 = new List<EnchantCandidates>(Split(tmp1));
            }
            //1つめのアイテムを取得する(同時に重複を無くす)
            var tmp2 = new HashSet<AbstractEnchantedItem>();
            foreach (var item in tmp1)
            {
                tmp2.Add(item[0]);
            }
            //結果を代入
            result = tmp2;
            //結果が0個ならfalse
            if (tmp2.Count == 0) return false;
            return true;

            static IEnumerable<EnchantCandidates> Split(IEnumerable<EnchantCandidates> aelist)
            {
                foreach (var ae in aelist)
                {
                    foreach (var newae in ae.GetNexts())
                    {
                        yield return newae;
                    }
                }
            }
        }
        public bool TryGetMinResult(out IEnumerable<AbstractEnchantedItem> result)
        {
            if (TryGetResult(out IEnumerable<AbstractEnchantedItem> tmp))
            {
                var filtered = Filter(tmp);
                result = filtered;
                return (new List<AbstractEnchantedItem>(filtered).Count != 0);
            }
            else
            {
                result = null;
                return false;
            }

            static IEnumerable<AbstractEnchantedItem> Filter(IEnumerable<AbstractEnchantedItem> fromThis)
            {
                //TotalMinEXPが最小なものに絞る
                var minEXP = int.MaxValue;
                var tmp1 = new List<AbstractEnchantedItem>();
                foreach (var item in fromThis)
                {
                    var totalMinEXP = item.TotalMinEXP;
                    if (totalMinEXP < minEXP)
                    {
                        tmp1.Clear();
                        tmp1.Add(item);
                        minEXP = totalMinEXP;
                    }
                    else if (totalMinEXP == minEXP)
                    {
                        tmp1.Add(item);
                    }
                    else
                    {
                        //何もしない
                    }
                }


                return tmp1;
            }
        }
    }
}
