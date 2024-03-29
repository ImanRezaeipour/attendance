using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Model;

namespace GTS.Clock.Model.Concepts
{
    public class PairableScndCnpValue : BaseScndCnpValue, IPairableConceptValue<IPair>
    {
        #region Constructors

        public PairableScndCnpValue()
            : this(new List<IPair>())
        { }

        public PairableScndCnpValue(IList<IPair> Pairs)
        {
            if (Pairs == null)
                this.Pairs = new List<IPair>();
            else
                this.Pairs = Pairs;
            this.Value = this.PairValues;
        }


        #endregion

        #region IPairableConceptValue<IPair> Members

        public virtual IList<IPair> Pairs
        {
            get;
            set;
        }

        public virtual IPair First
        {
            get { return this.Pairs.FirstOrDefault(); }
        }

        public virtual IPair Last
        {
            get { return this.Pairs.LastOrDefault(); }
        }

        public virtual IPair Intermediate
        {
            get { return this.Pairs[this.PairCount / 2]; }
        }

        public virtual int PairCount
        {
            get { return this.Pairs.Count; }
        }

        public virtual IPair PairPart(int Part)
        {
            return this.Pairs[Part];
        }

        /// <summary>
        /// جمع مقادیر زوج مرتب ها 
        /// </summary>
        public virtual int PairValues
        {
            get { return this.Pairs.Sum(x => x.Value); }
        }

        /// <summary>
        /// نمایش جمع مقادیر زوج مرتب به شکل ساعت:دقیقه
        /// </summary>
        public virtual string ExPairValues
        {
            get { return Utility.IntTimeToRealTime(this.PairValues); }
        }

        /// <summary>
        /// مقداردهی خصوصیت زوج مرتب با مقدار ارسالی
        /// </summary>
        /// <param name="Source">زوج مرتبی که باید انتصاب داده شود</param>
        public virtual void AddPair(IPair Source)
        {
            this.Pairs.Clear();
            this.Pairs.Add(new PairableScndCnpValuePair(Source.From, Source.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// مقداردهی خصوصیت زوج مرتب با مقادیر ارسالی
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید انتصاب داده شوند</param>
        public virtual void AddPairs(IList<IPair> Source)
        {
            this.Pairs.Clear();
            foreach (IPair pair in Source)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// مقداردهی خصوصیت زوج مرتب با زوج مرتب های پارامترهای ارسالی
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AddPairs(BaseScndCnpValue Source)
        {
            this.Pairs.Clear();
            foreach (IPair pair in ((PairableScndCnpValue)Source).Pairs)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// مقداردهی خصوصیت زوج مرتب با زوج مرتب های پارامترهای ارسالی
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AddPairsEx(BaseScndCnpValue Source)
        {
            var SourceExValue = this.Value - this.PairValues;

            this.Pairs.Clear();
            foreach (IPair pair in ((PairableScndCnpValue)Source).Pairs)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));

            this.Value = this.PairValues + SourceExValue;
        }

        /// <summary>
        /// مقداردهی خصوصیت زوج مرتب با مقادیر ارسالی
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب های مجوز که باید انتصاب داده شوند</param>
        public virtual void AddPairs(Permit Source)
        {
            this.Pairs.Clear();
            foreach (PermitPair pair in Source.Pairs)
            {
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));

            }
            this.Value = this.PairValues;
        }

        ///<summary>
        ///</summary>
        /// <param name="Value">حذف زوجها و مقدار/param>
        public virtual void ClearPairs()
        {
            this.Pairs.Clear();
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AppendPairs(IList<IPair> Source)
        {
            foreach (IPair pair in Source)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AppendPairsEx(IList<IPair> Source)
        {
            var SourceExValue = this.Value - this.PairValues;

            foreach (IPair pair in Source)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues + SourceExValue;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AppendPairs(IList<PermitPair> Source)
        {
            foreach (IPair pair in Source)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های پارامتر ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AppendPairs(PairableScndCnpValue Source)
        {
            foreach (IPair pair in Source.Pairs)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های شیفت ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Souarce">لیستی از زوج مرتب های شیفت که باید اضافه گردند</param>
        public virtual void AppendPairs(IList<ShiftPair> Souarce)
        {
            foreach (IPair pair in Souarce)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن زوج مرتب های پارامتر ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source">لیستی از زوج مرتب ها که باید اضافه گردند</param>
        public virtual void AppendPairs(BaseScndCnpValue Source)
        {
            foreach (IPair pair in ((PairableScndCnpValue)Source).Pairs)
                this.Pairs.Add(new PairableScndCnpValuePair(pair.From, pair.To, this));
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه نمودن مقدار ارسالی به خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void AppendPair(IPair Source)
        {
            if (Source != null)
            {
                this.Pairs.Add(new PairableScndCnpValuePair(Source.From, Source.To, this));
                this.Value = this.PairValues;
            }
        }

        /// <summary>
        /// حذف مقدار ارسالی از خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void RemovePair(IPair Source)
        {
            if (Source != null)
            {
                foreach (IPair pair in this.Pairs)
                {
                    if (pair.From == Source.From && pair.To == Source.To)
                    {
                        this.Pairs.Remove(pair);
                        break;
                    }
                }
                this.Value = this.PairValues;
            }
        }

        /// <summary>
        /// حذف مقدار ارسالی از خصوصیت زوج مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void RemovePairs(IList<IPair> Source)
        {
            foreach (IPair spair in Source)
            {
                foreach (IPair pair in this.Pairs)
                {
                    if (pair.From == spair.From && pair.To == spair.To)
                    {
                        this.Pairs.Remove(pair);
                        break;
                    }
                }
            }
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه کردن مقدار ارسالی از اولین زوجهای مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void IncreaseValue(int value)
        {
            int to = 17 * 60;//انتهای فرضی 5 بعد از ظهر
            if (this.PairCount > 0)
            {
                to = this.Pairs.OrderBy(x => x.From).Last().To;
            }
            else if (this.Person.GetShiftByDate(this.CalculationDate).Value > 0)
            {
                to = this.Person.GetShiftByDate(this.CalculationDate).PastedPairs.To;
            }

            PairableScndCnpValuePair pair = new PairableScndCnpValuePair(to, to + value, this);
            this.Pairs.Add(pair);
            this.Value = this.PairValues;
        }

        /// <summary>
        /// اضافه کردن مقدار ارسالی از اولین زوجهای مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void IncreaseValueEx(int value)
        {
            var SourceExValue = this.Value - this.PairValues;

            int to = 17 * 60;//انتهای فرضی 5 بعد از ظهر
            if (this.PairCount > 0)
            {
                to = this.Pairs.OrderBy(x => x.From).Last().To;
            }
            else if (this.Person.GetShiftByDate(this.CalculationDate).Value > 0)
            {
                to = this.Person.GetShiftByDate(this.CalculationDate).PastedPairs.To;
            }

            PairableScndCnpValuePair pair = new PairableScndCnpValuePair(to, to + value, this);
            this.Pairs.Add(pair);
            this.Value = this.PairValues + SourceExValue;
        }

        /// <summary>
        /// اضافه کردن مقدار ارسالی از اولین زوجهای مرتب
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from">ابتدای بازه شروع</param>
        public virtual void IncreaseValue(int value, int from)
        {
            int to = 17 * 60;//انتهای فرضی 5 بعد از ظهر
            if (this.PairCount > 0)
            {
                to = this.Pairs.OrderBy(x => x.From).Last().To;
            }
            else if (this.Person.GetShiftByDate(this.CalculationDate).Value > 0)
            {
                to = this.Person.GetShiftByDate(this.CalculationDate).PastedPairs.To;
            }

            PairableScndCnpValuePair pair = new PairableScndCnpValuePair(to, to + value, this);
            this.Pairs.Add(pair);
            this.Value = this.PairValues;
        }

        /// <summary>
        /// افزايش مقدار جفتها به صورت درصد
        /// </summary>
        /// <param name="percent">ضريب درصدي</param>
        public virtual void IncreasePairsValueByPercent(int percent)
        {
            this.Value += this.PairValues * percent / 100;
        }

        /// <summary>
        /// انتساب مقدار ارسالی به زوجهای مرتب
        /// </summary>
        /// <param name="Source"></param>
        public virtual void AssignValue(int value)
        {
            int from = 0;
            if (this.PairCount > 0)
            {
                from = this.Pairs.OrderBy(x => x.To).Last().To;
            }

            PairableScndCnpValuePair pair = new PairableScndCnpValuePair(from, from + value, this);
            this.ClearPairs();
            this.Pairs.Add(pair);
            this.Value = this.PairValues;
        }

        /// <summary>
        /// مجموع مقادیر زوج مرتب های موجود در قبل از زمان ارسالی را برمی گرداند 
        /// </summary>
        /// <param name="Time">زمانیکه باید مقادیر زوج مرتب های قبل از آن محاسبه شوند</param>
        /// <returns></returns>
        public virtual int TotalBeforeTime(int Time)
        {
            return this.Pairs
                        .Where(x => x.To <= Time)
                        .Sum(x => x.Value);
        }

        /// <summary>
        /// مجموع مقادیر زوج مرتب های موجود در بعد از زمان ارسالی را برمی گرداند 
        /// </summary>
        /// <param name="Time">زمانیکه باید مقادیر زوج مرتب های بعد از آن محاسبه شوند</param>
        /// <returns></returns>
        public virtual int TotalAfterTime(int Time)
        {
            return this.Pairs
                        .Where(x => x.To >= Time)
                        .Sum(x => x.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public virtual int GetPairsValueInRange(int start, int end)
        {
            if (this.Pairs.Count >= start && this.Pairs.Count >= end && start > 0 && end > 0)
            {
                int pairsSum = 0;
                for (int i = start - 1; i < end; i++)
                {
                    pairsSum += this.Pairs[i].Value;
                }
                return pairsSum;
            }
            else
            {
                throw new Exception("the range is out of index:GTS.Clock.Model.Concepts.PairableScndCnpValue.GetPairsValueInRange");
            }
        }

        /// <summary>
        /// این تابع زوج مرتب مشخص شده با شناسه ورودی را حذف می کند.
        /// در عین حال قبل از حذف مرتب سازی براساس "از" انجام می شود
        /// </summary>
        /// <param name="index"></param>
        public virtual void RemovePairAt(int index)
        {
            this.Pairs = this.Pairs.OrderBy(x => x.From).ToList();
            this.Pairs.RemoveAt(index);
        }

        /// <summary>
        /// وظیفه این تابع کم کردن مقدار ورودی از اولین زوج مرتب های "مفهوم زوج مرتبی" می باشد
        /// </summary>
        /// <returns>مقادیری که حذف شده اند</returns> 
        /// <param name="value"></param>
        public virtual IList<IPair> DecreasePairFromFirst(int value)
        {
            IList<IPair> pairList = new List<IPair>();
            if (value <= 0) return pairList;
            foreach (IPair pair in this.Pairs.OrderBy(p => p.From))
            {
                if (pair.Value <= value)
                {
                    //مقداری که باید کم شود بزرگتر از اندازه زوج مرتب است بنابراین
                    //کل زوج مرتب را حذف می کنیم
                    pairList.Add(pair);
                    value -= pair.Value;
                    this.RemovePair(pair);
                }
                else
                {
                    //مقداری که باید کم شود کوچکتر از اندازه زوج مرتب است بنابراین
                    //از مقدار "تا" زوج مرتب کم کرده و به عملیات خاتمه می دهیم
                    IPair p = new PairableScndCnpValuePair(pair.To - value, pair.To);
                    pairList.Add(p);
                    pair.To -= value;
                    break;
                }
            }
            this.Value = this.PairValues;
            return pairList;
        }

        /// <summary>
        /// وظیفه این تابع کم کردن مقدار ورودی از آخرین زوج مرتب های "مفهوم زوج مرتبی" می باشد
        /// </summary>
        /// <returns>مقادیری که حذف شده اند</returns>
        /// <param name="value"></param>
        public virtual PairableScndCnpValue DecreasePairFromLast(int value)
        {
            PairableScndCnpValue pairList = new PairableScndCnpValue();
            if (value <= 0) return pairList;
            foreach (IPair pair in this.Pairs.OrderByDescending(p => p.From))
            {
                if (pair.Value <= value)
                {
                    //مقداری که باید کم شود بزرگتر از اندازه زوج مرتب است بنابراین
                    //کل زوج مرتب را حذف می کنیم
                    value -= pair.Value;
                    pairList.Pairs.Add(pair);
                    this.RemovePair(pair);
                }
                else
                {
                    //مقداری که باید کم شود کوچکتر از اندازه زوج مرتب است بنابراین
                    //از مقدار "تا" زوج مرتب کم کرده و به عملیات خاتمه می دهیم
                    IPair p = new PairableScndCnpValuePair(pair.To - value, pair.To);
                    pairList.Pairs.Add(p);
                    pair.To -= value;
                    value = 0;
                    break;
                }
            }
            this.Value = this.PairValues;
            if (value > 0) //اضافه کار میتواند منفی شود.فلوچار قانون 92
            {
                this.Value = -1 * value;
            }
            return pairList;
        }

        #endregion

        #region Static Members

        public static void AppendPairToScndCnpValue(IPair Source, BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).AppendPair(Source);
        }

        public static void AddPairToScndCnpValue(IPair Source, BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).AddPair(Source);
        }

        public static void AddPairsToScndCnpValue(BaseScndCnpValue Source, BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).AddPairs(((PairableScndCnpValue)Source).Pairs);
        }

        public static void AppendPairsToScndCnpValue(BaseScndCnpValue Source, BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).AppendPairs(((PairableScndCnpValue)Source).Pairs);
        }

        public static void AppendPairsToScndCnpValue(BasePairableConceptValue<PermitPair> Source, BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).AppendPairs(Source.Pairs);
        }

        public static void ClearPairsValue(BaseScndCnpValue Destination)
        {
            if (Destination == null)
                Destination = new PairableScndCnpValue();
            ((PairableScndCnpValue)Destination).ClearPairs();
        }

        #endregion


    }

    public static class PairableScndCnpValueExtensions
    {
        public static PairableScndCnpValue SortOrderPairs(this PairableScndCnpValue Source)
        {
            if (!Source.Pairs.Any()) return Source;

            var innerList = new List<IPair>();
            innerList.AddRange(Source.Pairs.OrderBy(x => x.From).ThenBy(x => x.To));

            Source.Pairs.Clear();
            foreach (IPair pair in innerList)
            {
                Source.Pairs.Add(pair);
            }

            return Source;
        }
    }
}
