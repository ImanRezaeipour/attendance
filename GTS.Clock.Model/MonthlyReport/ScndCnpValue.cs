using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model.Concepts;


namespace GTS.Clock.Model.MonthlyReport
{
    public class ScndCnpValue : IEntity
    {

        #region Properties

        public virtual decimal ID
        {
            get;
            set;
        }

        public virtual decimal PersonId
        {
            get;
            set;
        }

        public virtual string KeyColumnName
        {
            get;
            set;
        }

        public virtual DateTime FromDate
        {
            get;
            set;
        }

        public virtual DateTime ToDate
        {
            get;
            set;
        }

        public virtual string FromPairs
        {
            get;
            set;
        }

        public virtual string ToPairs
        {
            get;
            set;
        }

        public virtual decimal Value
        {
            get;
            set;
        }

        public virtual DateTime PeriodicFromDate
        {
            get;
            set;
        }

        public virtual DateTime PeriodicToDate
        {
            get;
            set;
        }

        public virtual decimal PeriodicValue
        {
            get;
            set;
        }

        public virtual String Color { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1}", this.KeyColumnName, this.FromDate.Date);
        }

        #endregion

    }
}
