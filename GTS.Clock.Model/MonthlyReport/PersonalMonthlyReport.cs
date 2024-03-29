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

namespace GTS.Clock.Model.MonthlyReport
{
    #region Comments
    /// <h3>Changes</h3>
    /// 	<listheader>
    /// 		<th>Author</th>
    /// 		<th>Date</th>
    /// 		<th>Details</th>
    /// 	</listheader>
    /// 	<item>
    /// 		<term>Farhad Salavati</term>
    /// 		<description>8/9/2011</description>
    /// 		<description>Created</description>
    /// 	</item>

    #endregion

    public class PersonalMonthlyReport
    {
        public PersonalMonthlyReport()
        {
            this.DailyProceedTrafficDictionary = new Dictionary<DateTime, IList<CurrentProceedTraffic>>();
            this.DailyScndCnpValueDictionary = new Dictionary<DateTime, IDictionary<string, ScndCnpValue>>();
            this.PeriodicScndCnpValueDictionary = new Dictionary<string, ScndCnpValue>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId">شناسه شخص</param>
        /// <param name="date"></param>
        /// <param name="order">ترتیب ماه</param>
        /// <param name="minDate">تاریخ شروع محاسبه</param>
        /// <param name="maxDate">تاریخ انتها</param>
        public PersonalMonthlyReport(decimal personId, DateTime date, int order, DateTime minDate, DateTime maxDate)
        {
            this.PersonId = personId;
            this.Date = date;
            this.Order = order;
            this.MinDate = minDate;
            this.MaxDate = maxDate;
            this.DailyProceedTrafficDictionary = new Dictionary<DateTime, IList<CurrentProceedTraffic>>();
            this.DailyScndCnpValueDictionary = new Dictionary<DateTime, IDictionary<string, ScndCnpValue>>();
            this.PeriodicScndCnpValueDictionary = new Dictionary<string, ScndCnpValue>();
        }

        public PersonalMonthlyReport(decimal personId, DateTime minDate, DateTime maxDate)
        {
            this.PersonId = personId;
            this.MinDate = minDate;
            this.MaxDate = maxDate;
            this.DailyProceedTrafficDictionary = new Dictionary<DateTime, IList<CurrentProceedTraffic>>();
            this.DailyScndCnpValueDictionary = new Dictionary<DateTime, IDictionary<string, ScndCnpValue>>();
            this.PeriodicScndCnpValueDictionary = new Dictionary<string, ScndCnpValue>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the ID value.
        /// </summary>
        public virtual Decimal ID { get; set; }

        public virtual decimal PersonId { get; set; }

        public virtual int Order { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual DateTime MinDate { get; set; }

        public virtual DateTime MaxDate { get; set; }

        /// <summary>
        /// جهت استفاده در واسط کاربر
        /// </summary>
        public virtual String FromDate
        {
            get
            {
                if (LanguageName == LanguagesName.Parsi)
                {
                    return Utility.ToParsiCharacter(Utility.ToPersianDate(this.MinDate));
                }
                else
                {
                    return Utility.ToString(this.MinDate);
                }
            }
        }

        /// <summary>
        /// جهت استفاده در واسط کاربر
        /// </summary>
        public virtual String ToDate
        {
            get
            {
                if (LanguageName == LanguagesName.Parsi)
                {
                    return Utility.ToPersianDate(this.MaxDate);
                }
                else
                {
                    return Utility.ToString(this.MaxDate);
                }
            }
        }

        /// <summary>
        /// آیا دوره محاسبات جهت بازیابی وجود داشته است
        /// </summary>
        public virtual bool DataRangeIsValid
        {
            get
            {
                if (MinDate.Year == 1 || MaxDate.Year == 1 || FromDate.Equals("00001/01/01") || ToDate.Equals("00001/01/01"))
                {
                    return false;
                }
                return true;
            }
        }

        public virtual LanguagesName LanguageName
        {
            get;
            set;
        }

        public virtual IDictionary<DateTime, IList<CurrentProceedTraffic>> DailyProceedTrafficDictionary
        {
            get;
            set;
        }

        public virtual IDictionary<DateTime, IDictionary<string, ScndCnpValue>> DailyScndCnpValueDictionary
        {
            get;
            set;
        }

        public virtual IDictionary<string, ScndCnpValue> PeriodicScndCnpValueDictionary { get; set; }

        public virtual IList<PersonalMonthlyReportRow> PersonalMonthlyReportRows
        {
            get
            {
                IList<PersonalMonthlyReportRow> Result = new List<PersonalMonthlyReportRow>();
                DateRange MonthlyReportRange = new DateRange(this.MinDate, this.MaxDate, 0);
                this.LoadDailyProceedTrafficDictionary();
                this.LoadDailyScndCnpValueDictionary();
                Person prs = InitializePersonToLoadShiftPair();
                foreach (DateTime dt in MonthlyReportRange)
                {
                    IList<CurrentProceedTraffic> ProceedTrffics = null;
                    IDictionary<string, ScndCnpValue> DailyScndCnpValues = null;
                    this.DailyProceedTrafficDictionary.TryGetValue(dt, out ProceedTrffics);
                    if (ProceedTrffics == null)
                        ProceedTrffics = new List<CurrentProceedTraffic>();
                    this.DailyScndCnpValueDictionary.TryGetValue(dt, out DailyScndCnpValues);
                    if (DailyScndCnpValues == null)
                        DailyScndCnpValues = new Dictionary<string, ScndCnpValue>();
                    Result.Add(new PersonalMonthlyReportRow(prs, dt, this.LanguageName, ProceedTrffics, DailyScndCnpValues, this.PeriodicScndCnpValueDictionary));
                }
                return Result;
            }
        }

        public virtual IList<PersonalMonthlyReportRow> PersonalGanttChartRows
        {
            get
            {
                IList<PersonalMonthlyReportRow> Result = new List<PersonalMonthlyReportRow>();
                DateRange MonthlyReportRange = new DateRange(this.MinDate, this.MaxDate, 0);
                this.LoadPairlyScndCnpValueDictionary();
                Person prs = InitializePersonToLoadShiftPair();
                foreach (DateTime dt in MonthlyReportRange)
                {
                    IList<CurrentProceedTraffic> ProceedTrffics = null;
                    IDictionary<string, ScndCnpValue> DailyScndCnpValues = null;                   
                    this.DailyScndCnpValueDictionary.TryGetValue(dt, out DailyScndCnpValues);
                    if (DailyScndCnpValues == null)
                        DailyScndCnpValues = new Dictionary<string, ScndCnpValue>();
                    Result.Add(new PersonalMonthlyReportRow(prs, dt, this.LanguageName, ProceedTrffics, DailyScndCnpValues, this.PeriodicScndCnpValueDictionary));
                }
                return Result;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// ایجاد دیکشنری از ترددها با کلید تاریخ وظیفه این متد است
        /// </summary>
        private void LoadDailyProceedTrafficDictionary()
        {
            try
            {
                IList<CurrentProceedTraffic> DailyProceedTraffics = PersonalMonthlyReport.GetPrsMonthlyRptRepository(false).LoadDailyProceedTrafficList(this.PersonId, this.MinDate, this.MaxDate);
                foreach (CurrentProceedTraffic ProceedTraffic in DailyProceedTraffics)
                {
                    IList<CurrentProceedTraffic> DailyProceedTraffic = null;
                    this.DailyProceedTrafficDictionary.TryGetValue(ProceedTraffic.FromDate.Date, out DailyProceedTraffic);
                    if (DailyProceedTraffic == null)
                    {
                        DailyProceedTraffic = new List<CurrentProceedTraffic>();
                        DailyProceedTraffic.Add(ProceedTraffic);
                        this.DailyProceedTrafficDictionary.Add(ProceedTraffic.FromDate.Date, DailyProceedTraffic);
                    }
                    else
                    {
                        DailyProceedTraffic.Add(ProceedTraffic);
                    }
                }
            }
            catch (Exception ex)
            {
                GTSEngineLogger GTSlogger = new GTSEngineLogger();
                GTSlogger.Logger.Error(String.Format("خطا در هنگام واکشی ترددهای پرسنل:{0}، متن خطا: {1}", this.PersonId, Utility.GetExecptionMessage(ex)));
                GTSlogger.Flush();
            }
        }

        /// <summary>
        /// وظیفه ایجاد دیکشنری از نتایج محاسبات(مقادیر مفاهیم) با کلید "نام ستون" و اضافه کردن این دیکشنری
        /// به دیکشنری با کلید تاریخ به عهده ی این متد است
        /// </summary>
        protected virtual void LoadDailyScndCnpValueDictionary()
        {
            try
            {
                //واکشی نتایج محاسبات از پایگاه داده
                IList<ScndCnpValue> DailyScndCnpValues = PersonalMonthlyReport.GetPrsMonthlyRptRepository(false).LoadDailyScndCnpList(this.PersonId, this.Date.Date, this.Order);
                //گروه بندی داده ها بر اساس تاریخ
                var GroupedDailyScndCnpValue = DailyScndCnpValues.GroupBy(x => x.FromDate.Date);

                //به ازای تمامی تاریخ های موجود، یک دیکشنری با کلید آن تاریخ ساخته می شود
                foreach (DateTime dt in GroupedDailyScndCnpValue.Select(x => x.Key))
                {
                    IDictionary<string, ScndCnpValue> DailyScndCnpValueDic = null;
                    this.DailyScndCnpValueDictionary.TryGetValue(dt.Date, out DailyScndCnpValueDic);
                    //اگر دیکشنری ما به ازای تاریخ وجود ندارد باید ایجاد شود 
                    if (DailyScndCnpValueDic == null)
                    {
                        //تمامی مفاهیم محاسبه شده در آن تاریخ در دیکشنری با کلید "نام ستون" قرار می گیرند
                        DailyScndCnpValueDic = new Dictionary<string, ScndCnpValue>();
                        foreach (ScndCnpValue ScndCnpValue in GroupedDailyScndCnpValue.Where(x => x.Key == dt.Date).FirstOrDefault().ToList<ScndCnpValue>())
                        {
                            ScndCnpValue SCValue = null;
                            DailyScndCnpValueDic.TryGetValue(ScndCnpValue.KeyColumnName, out SCValue);
                            //اگر در دیکشنری در تاریخ مورد بررسی قبلا مفهومی با همین نام ستون وجود دارد
                            //به معنی آن است که یک مفهوم ماهانه از چندین مفهوم روزانه ساخته شده
                            //و مقادیر مفاهیم روزانه با یک کلید در واکشی داده ها بازیابی شده اند
                            //بنابراین باید نتایج مفاهیم روزانه را برای تاریخ مورد بررسی با هم جمع زده در آن روز نمایش دهیم
                            if (SCValue == null)
                            {
                                DailyScndCnpValueDic.Add(ScndCnpValue.KeyColumnName, ScndCnpValue);
                            }
                            else
                            {
                                SCValue.Value += ScndCnpValue.Value;
                            }

                        }
                        //دیکشنری ساخته شده از مفاهیم هر روز به دیکشنری اصلی با کلید تاریخ اضافه می شود 
                        this.DailyScndCnpValueDictionary.Add(dt.Date, DailyScndCnpValueDic);
                    }
                }
                foreach (var PeriodicScndCnpValue in DailyScndCnpValues.GroupBy(x => x.KeyColumnName))
                {
                    this.PeriodicScndCnpValueDictionary.Add(PeriodicScndCnpValue.First().KeyColumnName, PeriodicScndCnpValue.First());
                }

            }
            catch (Exception ex)
            {
                GTSEngineLogger GTSlogger = new GTSEngineLogger();
                GTSlogger.Logger.Error(String.Format("خطا در هنگام واکشی مقادیر محاسباتی پرسنل:{0}، متن خطا: {1}", this.PersonId, Utility.GetExecptionMessage(ex)));
                GTSlogger.Flush();
            }
        }

        /// <summary>
        /// وظیفه ایجاد دیکشنری از نتایج محاسبات(مقادیر مفاهیم) با کلید "نام ستون" و اضافه کردن این دیکشنری
        /// به دیکشنری با کلید تاریخ به عهده ی این متد است
        /// </summary>
        protected virtual void LoadPairlyScndCnpValueDictionary()
        {
            try
            {
                //واکشی نتایج محاسبات از پایگاه داده
                IList<ScndCnpValue> DailyScndCnpValues = PersonalMonthlyReport.GetPrsMonthlyRptRepository(false).LoadDailyScndCnpWithouthMonthlyList(this.PersonId, this.MinDate, this.MaxDate);
                //گروه بندی داده ها بر اساس تاریخ
                var GroupedDailyScndCnpValue = DailyScndCnpValues.GroupBy(x => x.FromDate.Date);

                //به ازای تمامی تاریخ های موجود، یک دیکشنری با کلید آن تاریخ ساخته می شود
                foreach (DateTime dt in GroupedDailyScndCnpValue.Select(x => x.Key))
                {
                    IDictionary<string, ScndCnpValue> DailyScndCnpValueDic = null;
                    this.DailyScndCnpValueDictionary.TryGetValue(dt.Date, out DailyScndCnpValueDic);
                    //اگر دیکشنری ما به ازای تاریخ وجود ندارد باید ایجاد شود 
                    if (DailyScndCnpValueDic == null)
                    {
                        //تمامی مفاهیم محاسبه شده در آن تاریخ در دیکشنری با کلید "نام ستون" قرار می گیرند
                        DailyScndCnpValueDic = new Dictionary<string, ScndCnpValue>();
                        foreach (ScndCnpValue ScndCnpValue in GroupedDailyScndCnpValue.Where(x => x.Key == dt.Date).FirstOrDefault().ToList<ScndCnpValue>())
                        {
                            ScndCnpValue SCValue = null;
                            DailyScndCnpValueDic.TryGetValue(ScndCnpValue.KeyColumnName, out SCValue);
                            //اگر در دیکشنری در تاریخ مورد بررسی قبلا مفهومی با همین نام ستون وجود دارد
                            //به معنی آن است که یک مفهوم ماهانه از چندین مفهوم روزانه ساخته شده
                            //و مقادیر مفاهیم روزانه با یک کلید در واکشی داده ها بازیابی شده اند
                            //بنابراین باید نتایج مفاهیم روزانه را برای تاریخ مورد بررسی با هم جمع زده در آن روز نمایش دهیم
                            if (SCValue == null)
                            {
                                DailyScndCnpValueDic.Add(ScndCnpValue.KeyColumnName, ScndCnpValue);
                            }
                            else
                            {
                                SCValue.Value += ScndCnpValue.Value;
                            }

                        }
                        //دیکشنری ساخته شده از مفاهیم هر روز به دیکشنری اصلی با کلید تاریخ اضافه می شود 
                        this.DailyScndCnpValueDictionary.Add(dt.Date, DailyScndCnpValueDic);
                    }
                }               
            }
            catch (Exception ex)
            {
                GTSEngineLogger GTSlogger = new GTSEngineLogger();
                GTSlogger.Logger.Error(String.Format("خطا در هنگام واکشی مقادیر محاسباتی پرسنل:{0}، متن خطا: {1}", this.PersonId, Utility.GetExecptionMessage(ex)));
                GTSlogger.Flush();
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Person InitializePersonToLoadShiftPair()
        {
            try
            {                
                IPersonRepository prsRep = Person.GetPersonRepository(false);
                //Person prs = prsRep.AttachPerson(this.PersonId);
                Person prs = prsRep.GetById(this.PersonId, true);
                prsRep.EnableEfectiveDateFilter(prs.ID, this.MinDate, this.MaxDate, DateTime.Now, DateTime.Now, this.MinDate, this.MaxDate);
                return prs;
            }
            catch (Exception ex)
            {
                ///TODO: Throw exception
                throw;
            }
        }

        public override string ToString()
        {
            return String.Format(" {0}->{1} ", this.MinDate, this.MaxDate);
        }

        #endregion

        #region Static Methods

        public static IPersonalMonthlyRptRepository GetPrsMonthlyRptRepository(bool Disconnectedly)
        {
            return RepositoryFactory.GetRepository<IPersonalMonthlyRptRepository, PersonalMonthlyReport>(Disconnectedly);
        }

        #endregion

    }
}