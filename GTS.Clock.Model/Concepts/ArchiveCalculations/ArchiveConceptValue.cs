using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure;
using GTS.Clock.Infrastructure.Log;
using GTS.Clock.Infrastructure.Exceptions;

namespace GTS.Clock.Model.Concepts
{  
    public class ArchiveConceptValue :IEntity
    {             
        #region Properties

        public virtual decimal ID
        {
            get;
            set;
        }

        public virtual int Value
        {
            get;
            set;
        }
        
        public virtual int ChangedValue
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

        public virtual DateTime ModifiedDate
        {
            get;
            set;
        }

        public virtual int Year { get; set; }

        public virtual int RangeOrder
        {
            get;
            set;
        }

        public virtual decimal ModifiedPersonId
        {
            get;
            set;
        }

        public virtual string ExValue
        {
            get { return Utility.IntTimeToRealTime(this.Value); }
        }

        public virtual SecondaryConcept Concept
        {
            get;
            set;
        }

        public virtual string Index
        {
            get;
            set;
        }

        public virtual decimal PersonId { get; set; }

        public virtual Person Person
        {
            get;
            set;
        }

        public virtual IList<GTS.Clock.Model.Temp.Temp> TempList { get; set; } 

        #endregion

        #region Methods

        /// <summary>
        /// یک شناسه منحصر به فرد برای درج در "هشت تی بل" ایجاد می نماید
        /// این شناسه براساس "شماره پرسنلی"، "شناسه مفهوم" و تاریخ مقداردهی مفهوم ایجاد می شود
        /// <remarks>اگر این تابع را قبل از مقداردهی به خصوصیات "شخص" و "مفهوم" فراخوانی نمایید با خطا مواجه خواهید شد</remarks>
        /// </summary>
        /// <param name="CalculationDate">تاریخ مقداردهی مفهوم</param>
        /// <returns>شناسه منحصر به فرد</returns>
        public virtual string GetIndex(PersianDateTime CalculationDate)
        {
            if (this.Person == null)
                throw new BaseException("خصوصیت شخص مقداردهی نشده است", "ArchiveConceptValue.GetIndex()");
            if (this.Concept == null)
                throw new BaseException("خصوصیت مفهوم مقداردهی نشده است", "ArchiveConceptValue.GetIndex()");
            return BaseScndCnpValue.GetIndex(this.Person.ID, this.Concept.IdentifierCode, CalculationDate);
        }

        /// <summary>
        /// یک شناسه منحصر به فرد برای درج در "هشت تی بل" ایجاد می نماید
        /// این شناسه براساس "شماره پرسنلی"، "شناسه مفهوم" و تاریخ مقداردهی مفهوم ایجاد می شود
        /// <remarks>اگر این تابع را قبل از مقداردهی به خصوصیات "شخص" و "مفهوم" فراخوانی نمایید با خطا مواجه خواهید شد</remarks>
        /// </summary>
        /// <param name="CalculationDate">تاریخ مقداردهی مفهوم</param>
        /// <returns>شناسه منحصر به فرد</returns>
        public virtual string GetIndex(DateTime CalculationDate)
        {
            if (this.Person == null)
                throw new BaseException("خصوصیت شخص مقداردهی نشده است", "ArchiveConceptValue.GetIndex()");
            if (this.Concept == null)
                throw new BaseException("خصوصیت مفهوم مقداردهی نشده است", "ArchiveConceptValue.GetIndex()");
            return BaseScndCnpValue.GetIndex(this.Person.ID, this.Concept.IdentifierCode, CalculationDate);
        }

        public override string ToString()
        {
            string str = " ";
            str += this.Concept.Name;
            str += " Old : " + Utility.IntTimeToTime(this.Value);
            str += " New : " + Utility.IntTimeToTime(this.ChangedValue);  

            return str;
        }


        #endregion
 
    }
}