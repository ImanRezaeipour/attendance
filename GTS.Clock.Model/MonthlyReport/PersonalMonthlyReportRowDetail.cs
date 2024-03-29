using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Infrastructure.Utility;

namespace GTS.Clock.Model.MonthlyReport
{
    public class PersonalMonthlyReportRowDetail
    {
        #region Properties

        public virtual decimal ID { get; set; }

        /// <summary>
        /// Gets or sets the Date value.
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String TheDate { get; set; }

        public virtual String DayName { get; set; }

        public virtual decimal PersonId { get; set; }

        public virtual string Froms { get; set; }

        public virtual string Tos { get; set; }

        public virtual string ExFrom 
        { 
            get
            {               
                return Utility.IntTimeToRealTime(Convert.ToInt32(this.Froms.Split(';')[0]));
            }
        }

        public virtual string ExTo 
        {
            get
            {
                return Utility.IntTimeToRealTime(Convert.ToInt32(this.Tos.Split(';')[0]));
            }
        }

        public virtual IList<IPair> Pairs
        {
            get
            {
                IList<IPair> pairs = new List<IPair>();
                if (!Utility.IsEmpty(this.Froms) && this.Froms[this.Froms.Length - 1] == ';')
                {
                    this.Froms = this.Froms.Remove(this.Froms.Length - 1, 1);
                }
                if (!Utility.IsEmpty(this.Tos) && this.Tos[this.Tos.Length - 1] == ';')
                {
                    this.Tos = this.Tos.Remove(this.Tos.Length - 1, 1);
                }

                string[] froms = Utility.Spilit(this.Froms, ';');
                string[] tos = Utility.Spilit(this.Tos, ';');
                for (int i = 0; i < froms.Length; i++)
                {
                    IPair pair = new PairableScndCnpValuePair();
                    pair.From = Utility.ToInteger(froms[i]);
                    
                    if (tos.Length > i)
                    {
                        pair.To = Utility.ToInteger(tos[i]);
                    }
                    pairs.Add(pair);
                }
                return pairs;
            }
        }
        
        public virtual string Color 
        {
            get;
            set;
        }

        public virtual string ScndCnpName { get; set; }
        public virtual Boolean ScndShowInDetail { get; set; }
        /// <summary>
        /// مقدار مفهوم ناخالص
        /// </summary>
        public virtual String ImpureValue { get; set; }

        public override string ToString()
        {
            return String.Format("{0} -> {1}", this.ExFrom, this.ExTo);
        }

        #endregion
    }
}