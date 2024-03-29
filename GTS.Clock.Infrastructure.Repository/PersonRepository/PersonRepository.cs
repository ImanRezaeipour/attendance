using System;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.Transform;
using GTS.Clock.Model;
using System.Linq;
using GTS.Clock.Infrastructure;
using GTS.Clock.Infrastructure.Exceptions;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure.NHibernateFramework;
using GTS.Clock.Infrastructure.Exceptions.UI;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Model.MonthlyReport;
using GTS.Clock.Model.Charts;
using GTS.Clock.Model.BaseInformation;
using System.IO;
using GTS.Clock.Model.UIValidation;
using GTS.Clock.Model.Security;
using GTS.Clock.Model.Contracts;
using System.Web.Configuration;

namespace GTS.Clock.Infrastructure.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public override string TableName
        {
            get { return "TA_Person"; }
        }
        public PersonRepository()
            : base()
        { }

        public PersonRepository(bool Disconnectedly)
            : base(Disconnectedly)
        { }

        int operationBatchSizeValue = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[OperationBatchSize.OperationBatchSizeKey.ToString()]);
        NHibernate.ISession NHSession = NHibernateSessionManager.Instance.GetSession();

        #region IPersonRepository Members

        public Person GetByBarcode(string Barcode)
        {
            return base.NHibernateSession.CreateCriteria(typeof(Person))
                .Add(Expression.Eq("IsDeleted", false))
                .Add(Expression.Eq("BarCode", Barcode))
                                         .UniqueResult<Person>();
        }

        public void EnableEfectiveDateFilter(decimal PersonId, DateTime FromDate, DateTime ToDate, DateTime beginYear, DateTime endYear, DateTime safeFromDate, DateTime safeToDate)
        {
            string strFromDate = FromDate.ToString("yyy/MM/dd");
            string strToDate = ToDate.ToString("yyyy/MM/dd");
            string strEndYear = endYear.ToString("yyy/MM/dd");
            string strBeginYear = beginYear.ToString("yyyy/MM/dd");
            string strSafeFromDate = safeFromDate.ToString("yyy/MM/dd");
            string strSafeToDate = safeToDate.ToString("yyyy/MM/dd");
            NhibernateFilters filters = base.NhibernateFilters;
            NhibernateFilter filter = new NhibernateFilter();
            filter.FilterName = "effectiveDate";
            filter.Add("fromDate", strFromDate);
            filter.Add("toDate", strToDate);
            filter.Add("personId", PersonId);
            filter.Add("endYear", strEndYear);
            filter.Add("beginYear", strBeginYear);
            filter.Add("safeFromDate", strSafeFromDate);
            filter.Add("safeToDate", strSafeToDate);
            filters.Clear();
            filters.Add(filter);
            base.NHibernateSession.EnableFilter("effectiveDate")
                        .SetParameter("fromDate", strFromDate)
                        .SetParameter("toDate", strToDate)
                        .SetParameter("personId", PersonId)
                        .SetParameter("endYear", strEndYear)
                        .SetParameter("beginYear", strBeginYear)
                        .SetParameter("safeFromDate", strSafeFromDate)
                        .SetParameter("safeToDate", strSafeToDate);
        }

        public void EnableEfectiveDateFilter(decimal PersonId, DateTime FromDate, DateTime ToDate)
        {
            string strFromDate = FromDate.ToString("yyy/MM/dd");
            string strToDate = ToDate.ToString("yyyy/MM/dd");
            NhibernateFilters filters = base.NhibernateFilters;
            NhibernateFilter filter = new NhibernateFilter();
            filter.FilterName = "effectiveDate";
            filter.Add("fromDate", strFromDate);
            filter.Add("toDate", strToDate);
            filter.Add("personId", PersonId);
            filter.Add("endYear", "");
            filter.Add("beginYear", "");
            filter.Add("safeFromDate", "");
            filter.Add("safeToDate", "");
            filters.Clear();
            filters.Add(filter);
            base.NHibernateSession.EnableFilter("effectiveDate")
                        .SetParameter("fromDate", strFromDate)
                        .SetParameter("toDate", strToDate)
                        .SetParameter("personId", PersonId)
                        .SetParameter("endYear", "")
                        .SetParameter("beginYear", "")
                        .SetParameter("safeFromDate", "")
                        .SetParameter("safeToDate", "");
        }

        public void DisableEfectiveDateFilter()
        {
            base.NhibernateFilters.Clear();
            base.NHibernateSession.DisableFilter("effectiveDate");
        }

        public void DeleteProceedTraffic(ProceedTraffic proceedTraffic)
        {
            string SQLCommand = String.Format("DELETE " +
                                              "FROM TA_ProceedTraffic " +
                                              "WHERE ProceedTraffic_ID= {0}", proceedTraffic.ID);
            base.RunSQL(SQLCommand);
        }

        public void DeleteProceedTraffic(decimal personId, DateTime fromDate)
        {
            string SQLCommand = @"delete from TA_ProceedTraffic
                                         where ProceedTraffic_PersonId = :personId
                                         and ProceedTraffic_FromDate >= :fromDate";

            base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .SetParameter("personId", personId)
                .SetParameter("fromDate", fromDate.Date)
                .ExecuteUpdate();

            /*string SQLCommand1 = String.Format(@"DELETE FROM ProceedTraffic
                                               WHERE ProceedTraffic_PersonId = {0} AND ProceedTraffic_FromDate >= {1}", personId, fromDate);

            base.RunHQL(SQLCommand1)*/
        }


        /// <summary>
        /// نتایج مفاهیم در تاریخ مشخص شده برای پرسنل ارسالی را پاک می نماید
        /// </summary>
        /// <param name="PersonID"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        public void DeleteScndCnpValue(Decimal PersonID, DateTime FromDate, DateTime ToDate)
        {
            /* string SQLCommand = String.Format(@" DELETE FROM TA_SecondaryConceptValue  
                                                  WHERE ScndCnpValue_PersonId = {0} 
                                                  AND 
                                                  (
                                                      (ScndCnpValue_FromDate BETWEEN '{1}' AND '{2}')   
                                                      OR 
                                                      (ScndCnpValue_ToDate BETWEEN '{1}' AND '{2}')   
                                                      OR 
                                                      ('{0}' >= ScndCnpValue_FromDate AND ScndCnpValue_ToDate >= '{2}')
                                                  )", PersonID, FromDate.ToShortDateString(), ToDate.ToShortDateString());
             */
            string HQLCommand = String.Format(" DELETE FROM " +
                                                "BaseScndCnpValue bsScndCnpVal " +
                                                "WHERE bsScndCnpVal.Person.id = {0} " +
                                                "AND " +
                                                "((bsScndCnpVal.FromDate BETWEEN '{1}' AND '{2}') " +
                                                "  OR " +
                                                "(bsScndCnpVal.ToDate BETWEEN '{1}' AND '{2}') " +
                                                "  OR " +
                                                "('{1}' >= bsScndCnpVal.FromDate AND bsScndCnpVal.ToDate >= '{2}'))", PersonID, FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));

            // base.RunSQL(SQLCommand);
            //base.NHibernateSession.CreateSQLQuery(SQLCommand).ExecuteUpdate();
            base.NHibernateSession.CreateQuery(HQLCommand).ExecuteUpdate();
        }

        /// <summary>
        /// در اینجا یک "پروسیجر ذخیره شده ی" "اسکیوال" فراخوانی می شود که
        /// جدول "خروجی" پرسنل مشخص شده را در تاریخ ارسالی پر می نماید
        /// </summary>
        /// <param name="Barcode"></param>
        /// <param name="date"></param>
        public void UpdatePTable(string Barcode, PersianDateTime date)
        {
            IQuery query = this.NHibernateSession
                                .GetNamedQuery("UpdatePTableQuery")
                                .SetString("barCode", Barcode)
                                .SetString("year", date.Year.ToString())
                                .SetString("month", date.Month.ToString())
                                .SetString("day", date.Day.ToString())
                                .SetString("GregorianDate", date.GregorianDate.ToString("yyyy/MM/dd"));
            query.List();
        }

        /// <summary>
        /// شی ارسال شده را دوباره بارگذاری می نماید
        /// </summary>
        /// <param name="Entity"></param>
        public override void Refresh(Person Entity)
        {
            if (Entity != null)
            {
                //Entity.shiftList.Clear();
                base.Refresh(Entity);
            }
        }

        /// <summary>
        /// با ارسال "جستجوی" مستقیم برروی پایگاه داده مقدار مفهوم مورد نظر را براساس شناسه ی ارسالی برمی گرداند
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public BaseScndCnpValue GetScndCnpValueByIndex(string Index)
        {
            //بدلیل تکراری برگرداندن کامنت شد تا بعدا تست دقیق شود - 5 تیر 1393
            //return base.NHibernateSession.QueryOver<BaseScndCnpValue>()
            //                             .Where(x => x.Index == Index)
            //                             .SingleOrDefault();

            IList<BaseScndCnpValue> list = base.NHibernateSession.QueryOver<BaseScndCnpValue>()
                                        .Where(x => x.Index == Index)
                                        .List();
            return list.FirstOrDefault();
        }

        /// <summary>
        /// اگر بارکد تهی باشد نباید در لیست جواب بیاید
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="conOp"></param>
        /// <param name="cretriaParam"></param>
        /// <returns></returns>
        public override IList<Person> GetByCriteriaByPage(int pageIndex, int pageSize, ConditionOperations conOp, params CriteriaStruct[] cretriaParam)
        {
            ICriteria crit = this.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            for (int i = 0; i < cretriaParam.Length; i++)
            {
                CriteriaStruct c = cretriaParam[i];

                switch (c.Operation)
                {
                    case CriteriaOperation.Equal:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Eq(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Eq(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.NotEqual:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Not(Restrictions.Eq(c.PropertyName, c.Value)));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Not(Restrictions.Eq(c.PropertyName, c.Value)));
                        break;
                    case CriteriaOperation.GreaterThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Gt(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Gt(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.LessThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Lt(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Lt(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.GreaterEqThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Ge(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Ge(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.LessEqThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Le(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Le(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.Like:
                        if (conOp == ConditionOperations.AND)
                        {
                            if (c.Value is string)
                            {
                                crit.Add(Restrictions.Like(c.PropertyName, c.Value.ToString(), MatchMode.Anywhere));
                            }
                            else
                            {
                                crit.Add(Restrictions.Like(c.PropertyName, c.Value));
                            }
                        }
                        else if (conOp == ConditionOperations.OR)
                        {
                            if (c.Value is string)
                            {
                                disjunction.Add(Restrictions.Like(c.PropertyName, c.Value.ToString(), MatchMode.Anywhere));
                            }
                            else
                            {
                                disjunction.Add(Restrictions.Like(c.PropertyName, c.Value));
                            }
                        }
                        break;
                }
            }
            if (cretriaParam.Length > 0)
            {
                crit.Add(disjunction);
            }
            crit.Add(Restrictions.IsNotNull(Utility.Utility.GetPropertyName(() => new Person().BarCode)));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            IList<Person> list = crit.SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize).List<Person>();
            return list;
        }

        /// <summary>
        /// اگر بارکد تهی باشد نباید در لیست جواب بیاید
        /// </summary>
        /// <param name="conOp"></param>
        /// <param name="cretriaParam"></param>
        /// <returns></returns>
        public int GetCountByCriteriaNotNull(ConditionOperations conOp, params CriteriaStruct[] cretriaParam)
        {
            ICriteria crit = this.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            for (int i = 0; i < cretriaParam.Length; i++)
            {
                CriteriaStruct c = cretriaParam[i];

                switch (c.Operation)
                {
                    case CriteriaOperation.Equal:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Eq(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Eq(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.NotEqual:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Not(Restrictions.Eq(c.PropertyName, c.Value)));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Not(Restrictions.Eq(c.PropertyName, c.Value)));
                        break;
                    case CriteriaOperation.GreaterThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Gt(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Gt(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.LessThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Lt(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Lt(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.GreaterEqThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Ge(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Ge(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.LessEqThan:
                        if (conOp == ConditionOperations.AND)
                            crit.Add(Restrictions.Le(c.PropertyName, c.Value));
                        else if (conOp == ConditionOperations.OR)
                            disjunction.Add(Restrictions.Le(c.PropertyName, c.Value));
                        break;
                    case CriteriaOperation.Like:
                        if (conOp == ConditionOperations.AND)
                        {
                            if (c.Value is string)
                            {
                                crit.Add(Restrictions.Like(c.PropertyName, c.Value.ToString(), MatchMode.Anywhere));
                            }
                            else
                            {
                                crit.Add(Restrictions.Like(c.PropertyName, c.Value));
                            }
                        }
                        else if (conOp == ConditionOperations.OR)
                        {
                            if (c.Value is string)
                            {
                                disjunction.Add(Restrictions.Like(c.PropertyName, c.Value.ToString(), MatchMode.Anywhere));
                            }
                            else
                            {
                                disjunction.Add(Restrictions.Like(c.PropertyName, c.Value));
                            }
                        }
                        break;
                }
            }
            if (cretriaParam.Length > 0)
            {
                crit.Add(disjunction);
            }
            crit.Add(Restrictions.IsNotNull(Utility.Utility.GetPropertyName(() => new Person().BarCode)));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            int count = (int)crit.SetProjection(Projections.Count("ID")).UniqueResult();
            return count;
        }

        public int GetPersonCount(decimal userId)
        {
            DetachedCriteria criteria = DetachedCriteria.For(this.persistanceType);
            criteria.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            criteria.Add(Restrictions.IsNotNull(Utility.Utility.GetPropertyName(() => new Person().BarCode)));
            criteria.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            criteria.Add(Expression.Sql("prs_Id in (select * from fn_GetAccessiblePersons(0,?,?))", new object[] { userId, (int)PersonCategory.Public }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Int32 }));
            int count = 0;
            try
            {
                count = (int)criteria.GetExecutableCriteria(NHibernateSession)
                        .SetProjection(Projections.Count("ID")).UniqueResult();
            }
            finally
            {
                if (this.disconnectedly)
                    this.NHibernateSession.Disconnect();
            }
            return count;
        }

        /// <summary>
        /// صفحه بندی روی اشخاصی که شماره پرسنلی آنها تهی نباشد
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<Person> GetAllByPage(decimal userId, int pageIndex, int pageSize)
        {
            DetachedCriteria criteria = DetachedCriteria.For(this.persistanceType);
            criteria.Add(Restrictions.IsNotNull(Utility.Utility.GetPropertyName(() => new Person().BarCode)));
            criteria.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            criteria.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            criteria.Add(Expression.Sql("prs_Id in (select * from fn_GetAccessiblePersons(0,?,?))", new object[] { userId, (int)PersonCategory.Public }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Int32 }));
            IList<Person> entities = null;
            try
            {
                entities = criteria.GetExecutableCriteria(NHibernateSession)

                    .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize)
                    .List<Person>() as IList<Person>;
            }
            finally
            {
                if (this.disconnectedly)
                    this.NHibernateSession.Disconnect();
            }
            return entities;
        }

        #region Image Region
        ///بدلیل عدم استفاده از مدل در ذخیره و بازیابی عکس پرسنل این عملیات در اینجا بصورت مستقیم انجام می شود

        /// <summary>
        /// بروزرسانی عکس پرسنل
        /// </summary>
        /// <param name="personDtlId"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public decimal UpdatePersonImage(decimal personDtlId, string image)
        {
            try
            {
                base.Transact<int>(() => NHibernateSession.CreateSQLQuery(String.Format("UPDATE {0} " +
                                                                                        "SET PrsDtl_Image = :image " +
                                                                                        "WHERE PrsDtl_ID = {1}", "TA_PersonDetail", personDtlId)).SetParameter("image", image).ExecuteUpdate());
                return personDtlId;
            }
            catch (Exception ex)
            {
                throw new UpdatPersonImageException(UIFatalExceptionIdentifiers.UpdatePersonImageHasError, ex.Message, "");
            }
        }

        /// <summary>
        /// بازیابی عکس پرسنل
        /// </summary>
        /// <param name="personDtlId"></param>
        /// <returns></returns>
        public string GetPersonImage(decimal personDtlId)
        {
            return base.Transact<string>(() => NHibernateSession.QueryOver<PersonDetail>()
                                                    .Select(x => x.Image)
                                                    .Where(x => x.ID == personDtlId)
                                                    .SingleOrDefault<string>());
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId">شناسه شخص</param>
        /// <param name="date">تاریخ جهت بررسی تاریخ انتساب شخص</param>
        /// <param name="order">ترتیب ماه</param>
        /// <returns></returns>
        public PersonalMonthlyReport GetPersonalMonthlyReport(decimal personId, DateTime date, int order)
        {
            return NHibernateSession.GetNamedQuery("GetPersonalMonthlyReport")
                                    .SetParameter("PersonId", personId)
                                    .SetParameter("Date", date)
                                    .SetParameter("Order", order)
                                    .UniqueResult<PersonalMonthlyReport>();

        }

        public Person AttachPerson(decimal PrsId)
        {
            try
            {
                Person p = new Person() { ID = PrsId };
                NHibernateSession.Refresh(p, LockMode.Read);
                NHibernateSession.SetReadOnly(p, true);
                return p;
            }
            catch (Exception ex)
            {
                throw new NHibernateException("پرسنلی با این شناسه قبلا در جلسه وجود داشته است", ExceptionType.FATAL, "PersonRepository.AttachPerson", ex);
            }
        }

        public IList<decimal> GetAllActivePersonIds()
        {
            string HQLCommnad = @" select prs.ID from Person as prs
                                  Where prs.IsDeleted=false AND prs.Active=true";

            IList<decimal> list = base.NHibernateSession.CreateQuery(HQLCommnad)
               .List<decimal>();
            return list;

        }
        #endregion

        public bool ExistsPerson(decimal personId)
        {
            string SQLQuery = " SELECT Count(*) FROM TA_Person WHERE prs_IsDeleted=0 AND prs_ID=:personId ";

            int count = base.NHibernateSession.CreateSQLQuery(SQLQuery)
                                            .SetParameter("personId", personId)
                                            .List<int>().First();
            return count > 0;
        }

        /// <summary>
        /// پرسنل را براساس ایستگاه کنترلی برمیگرداند
        /// </summary>
        /// <param name="controlStationIds"></param>
        /// <returns></returns>
        public IList<decimal> GetAllPersonByControlStaion(decimal[] controlStationIds)
        {
            if (controlStationIds == null || controlStationIds.Length == 0)
                return new List<decimal>();
            string SQLQuery = string.Empty;
            IList<decimal> prsIds = new List<decimal>();
            if (controlStationIds.Count() < this.operationBatchSizeValue && this.operationBatchSizeValue < 2100)
            {
                SQLQuery = @" SELECT prs_ID FROM TA_Person person
                                 Inner Join TA_PersonTASpec personSpec
                                 on person.Prs_ID = personSpec.prsTA_ID
                                 WHERE person.Prs_IsDeleted=0 AND personSpec.prsTA_ControlStationId in (:ctrlSationIds)";
                prsIds = base.NHibernateSession.CreateSQLQuery(SQLQuery)
                .SetParameterList("ctrlSationIds", base.CheckListParameter(controlStationIds))
                                           .List<decimal>();
            }
            else
            {
                TempRepository tempRep = new TempRepository(false);
                string operationGUID = tempRep.InsertTempList(controlStationIds);
                SQLQuery = @" SELECT prs_ID FROM TA_Person person
                                 Inner Join TA_PersonTASpec personSpec
                                 on person.Prs_ID = personSpec.prsTA_ID
                                 Inner Join TA_Temp temp
                                 on personSpec.prsTA_ControlStationId=temp.temp_ObjectID 
                                 WHERE person.Prs_IsDeleted=0 and temp_OperationGUID= :operationGUID";
                prsIds = base.NHibernateSession.CreateSQLQuery(SQLQuery)
                .SetParameterList("operationGUID", operationGUID)
                                           .List<decimal>();
                tempRep.DeleteTempList(operationGUID);
            }


            return prsIds;
        }

        public IList<Department> GetAllPersonnelDepartmentParents(decimal departmentID)
        {
            IList<Department> DepartmentsList = new List<Department>();

            Department childDepartment = NHibernateSession.QueryOver<Department>()
                            .Where(department => department.ID == departmentID)
                            .List<Department>()
                            .FirstOrDefault();

            if (childDepartment != null)
                DepartmentsList.Add(childDepartment);
            else
                return DepartmentsList;

            this.GetAllPersonnelDepartmentParents(ref DepartmentsList, childDepartment);
            return DepartmentsList.Reverse().ToList<Department>();
        }

        private void GetAllPersonnelDepartmentParents(ref IList<Department> DepartmentsList, Department childDepartment)
        {
            Department parentDepartment = NHibernateSession.QueryOver<Department>()
                                          .Where(department => department.ID == childDepartment.ParentID)
                                          .List<Department>()
                                          .FirstOrDefault();
            if (parentDepartment != null)
            {
                DepartmentsList.Add(parentDepartment);
                this.GetAllPersonnelDepartmentParents(ref DepartmentsList, parentDepartment);
            }
        }

        /// <summary>
        /// یک شخص را بطور منطقی از دیتابیس حذف مینماید
        /// </summary>
        /// <param name="personID"></param>
        public void DeletePerson(decimal personID)
        {
            string SQLCommand = @"update TA_Person
                                set prs_IsDeleted=1
                                where prs_ID =:personId";
            base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .SetParameter("personId", personID)
                .ExecuteUpdate();

            UserRepository userRep = new UserRepository();
            userRep.DeleteDeletedPersonUsers(personID);
        }

        #region Search

        public IList<Person> Search(PersonSearchProxy proxy, decimal userId, decimal managerId, PersonCategory searchCat, int pageIndex, int pageSize)
        {
            const string PersonDetailAlias = "prsDtl";
            const string WorkGroupAlias = "wg";
            const string RuleGroupAlias = "rg";
            const string CalculationDateRangeGroupAlias = "cdrg";
            const string DepartmentAlias = "dep";
            const string OrganizationUnitAlias = "organ";
            const string PersonTASpecAlias = "prsTs";
            const string GradeAlias = "grade";
            const string EmploymentAlias = "emp";
            const string ContractAlias = "con";
            const string CostCenterAlias = "CostCenter";
            ICriteria crit = base.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            Junction integratedSearchDisjunction = Restrictions.Disjunction();
            // crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            //crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetail), PersonDetailAlias);
            crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetailList), PersonDetailAlias);

            //حذف شده 
            if (proxy.PersonIsDeleted == true)
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), true));
            else
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            //فعال
            if (proxy.PersonActivateState != null)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Active), (bool)proxy.PersonActivateState));
            }

            //کد پرسنلی
            if (!Utility.Utility.IsEmpty(proxy.PersonCode))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.PersonCode, MatchMode.Anywhere));
            }

            //کد ملی
            if (!Utility.Utility.IsEmpty(proxy.MelliCode))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MeliCode), proxy.MelliCode, MatchMode.Anywhere));
            }

            //نام
            if (!Utility.Utility.IsEmpty(proxy.FirstName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.FirstName, MatchMode.Anywhere));
            }

            //نام خانوادگی
            if (!Utility.Utility.IsEmpty(proxy.LastName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.LastName, MatchMode.Anywhere));
            }

            //نام پدر
            if (!Utility.Utility.IsEmpty(proxy.FatherName))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().FatherName), proxy.FatherName, MatchMode.Anywhere));
            }

            //جنسیت ,پیش فرض آن از واسط کاربر -1 است
            if (!Utility.Utility.IsEmpty(proxy.Sex) && proxy.Sex >= 0)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Sex), proxy.Sex));
            }

            //شماره کارت
            if (!Utility.Utility.IsEmpty(proxy.CartNumber))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.CartNumber));
            }
            //شماره استخدام
            if (!Utility.Utility.IsEmpty(proxy.EmployeeNumber))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().EmploymentNum), proxy.EmployeeNumber));
            }
            //محل تولد
            if (!Utility.Utility.IsEmpty(proxy.BirthPlace))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthPlace), proxy.BirthPlace, MatchMode.Anywhere));
            }
            //نظام وضیفه , پیش فرض آن از واسط کاربر 0 است
            if (!Utility.Utility.IsEmpty(proxy.Military) && proxy.Military > 0)
            {
                crit.Add(Restrictions.Eq(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MilitaryStatus), proxy.Military));
            }

            //تحصیلات
            if (!Utility.Utility.IsEmpty(proxy.Education))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().Education), proxy.Education, MatchMode.Anywhere));
            }

            //تاهل , پیش فرض آن از واسط کاربر 0 است
            if (!Utility.Utility.IsEmpty(proxy.MaritalStatus) && proxy.MaritalStatus > 0)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().MaritalStatus), proxy.MaritalStatus));
            }

            //شروع تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.FromBirthDate))
            {
                crit.Add(Restrictions.Ge(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.FromBirthDate)));
            }

            //پایان تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.ToBirthDate))
            {
                crit.Add(Restrictions.Le(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.ToBirthDate)));
            }

            //شروع تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.FromEmploymentDate))
            {
                crit.Add(Restrictions.Ge(Utility.Utility.GetPropertyName(() => new Person().EmploymentDate), Utility.Utility.ToMildiDateTime(proxy.FromEmploymentDate)));
            }

            //پایان تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.ToEmploymentDate))
            {
                crit.Add(Restrictions.Le(Utility.Utility.GetPropertyName(() => new Person().EndEmploymentDate), Utility.Utility.ToMildiDateTime(proxy.ToEmploymentDate)));
            }

            //بخش

            if (!Utility.Utility.IsEmpty(proxy.DepartmentListId))
            {
                crit.CreateAlias("department", DepartmentAlias);

                if (proxy.IncludeSubDepartments)
                {
                    disjunction.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));

                    foreach (decimal item in proxy.DepartmentListId)
                    {
                        disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + item.ToString() + ",", MatchMode.Anywhere));
                    }


                }
                else
                {

                    crit.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));
                }

            }
            //پست سازمانی
            if (!Utility.Utility.IsEmpty(proxy.OrganizationUnitId))
            {
                crit.CreateAlias("OrganizationUnitList", OrganizationUnitAlias);
                crit.Add(Restrictions.Eq(OrganizationUnitAlias + "." + Utility.Utility.GetPropertyName(() => new OrganizationUnit().ID), (decimal)proxy.OrganizationUnitId));
            }
            //رتبه
            if (!Utility.Utility.IsEmpty(proxy.GradeId))
            {
                crit.CreateAlias("grade", GradeAlias);
                crit.Add(Restrictions.Eq(GradeAlias + "." + Utility.Utility.GetPropertyName(() => new Grade().ID), (decimal)proxy.GradeId));
            }
            //مرکز هزینه
            if (!Utility.Utility.IsEmpty(proxy.CostCenterId))
            {
                crit.CreateAlias("costCenter", CostCenterAlias);
                crit.Add(Restrictions.Eq(CostCenterAlias + "." + Utility.Utility.GetPropertyName(() => new CostCenter().ID), (decimal)proxy.CostCenterId));
            }
            //گروه کاری
            if (!Utility.Utility.IsEmpty(proxy.WorkGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonWorkGroupList), WorkGroupAlias);
                crit.Add(Restrictions.Eq(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().WorkGroup), new WorkGroup() { ID = (decimal)proxy.WorkGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.WorkGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().FromDate), Utility.Utility.ToMildiDateTime(proxy.WorkGroupFromDate)));
                }
            }

            //گروه قوانین
            if (!Utility.Utility.IsEmpty(proxy.RuleGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRuleCatAssignList), RuleGroupAlias);
                crit.Add(Restrictions.Eq(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().RuleCategory), new RuleCategory() { ID = (decimal)proxy.RuleGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.RuleGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().FromDate), Utility.Utility.ToString(proxy.RuleGroupFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().ToDate), Utility.Utility.ToString(proxy.RuleGroupToDate)));
                }
            }
            //گروه قوانین واسط کاربری
            //if (!Utility.Utility.IsEmpty(proxy.UiValidationGroupID))
            //{
            //    crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
            //    crit.Add(Restrictions.Eq(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().UIValidationGroup), new UIValidationGroup() { ID = (decimal)proxy.UiValidationGroupID }));
            //}

            //محدوده محاسبات
            if (!Utility.Utility.IsEmpty(proxy.CalculationDateRangeId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRangeAssignList), CalculationDateRangeGroupAlias);
                crit.Add(Restrictions.Eq(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().CalcDateRangeGroup), new CalculationRangeGroup() { ID = (decimal)proxy.CalculationDateRangeId }));

                if (!Utility.Utility.IsEmpty(proxy.CalculationFromDate))
                {
                    crit.Add(Restrictions.Ge(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.CalculationFromDate)));
                }
            }

            //ایستگاه کنترل

            if (!Utility.Utility.IsEmpty(proxy.ControlStationListId))
            {
                List<ControlStation> controlStationList = new List<ControlStation>();
                foreach (decimal item in proxy.ControlStationListId)
                {
                    controlStationList.Add(new ControlStation() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), controlStationList));
            }
            //نوع استخدام

            if (!Utility.Utility.IsEmpty(proxy.EmploymentTypeListId))
            {
                crit.CreateAlias("employmentType", EmploymentAlias);
                crit.Add(Restrictions.In(EmploymentAlias + "." + Utility.Utility.GetPropertyName(() => new EmploymentType().ID), proxy.EmploymentTypeListId.ToArray()));


            }
            // گروه واسط کاربری
            if (!Utility.Utility.IsEmpty(proxy.UIValidationGroupListId))
            {
                List<UIValidationGroup> uiValidationGroupList = new List<UIValidationGroup>();
                foreach (decimal item in proxy.UIValidationGroupListId)
                {
                    uiValidationGroupList.Add(new UIValidationGroup() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().UIValidationGroup), uiValidationGroupList));
            }
            //قرارداد
            if (!Utility.Utility.IsEmpty(proxy.ContractId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonContractAssignmentList), ContractAlias);
                crit.Add(Restrictions.Eq(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().Contract), new Contract() { ID = (decimal)proxy.ContractId }));
                crit.Add(Restrictions.Eq(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().IsDeleted), false));

                if (!Utility.Utility.IsEmpty(proxy.ContractFromDate))
                {
                    crit.Add(Restrictions.Ge(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.ContractFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().ToDate), Utility.Utility.ToMildiDateTime(proxy.ContractToDate)));
                }
            }
            //اشخاص مشخص شده
            if (!Utility.Utility.IsEmpty(proxy.PersonIdList))
            {
                crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), CheckListParameter(proxy.PersonIdList)));
            }

            //جستجو در بین مدیران و اپراتورها
            if (proxy.SearchInCategory != PersonCategory.Public
                && !Utility.Utility.IsEmpty(proxy.SearchInCategory))
            {
                if (proxy.SearchInCategory == PersonCategory.Manager)
                {
                    IList<Person> personList = new ManagerRepository(false).GetAllManager();
                    var ids = from person in personList
                              select person.ID;
                    IList<decimal> idList = ids.ToList<decimal>();

                    crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), idList.ToArray()));
                }
            }

            if (!Utility.Utility.IsEmpty(proxy.IntegratedSearchTerm))
            {
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
            }

            IList<Person> list = new List<Person>();
            if (proxy.PersonIsDeleted == true)
                crit.Add(Expression.Sql(" prs_Id in (select * from fn_GetAccessibleDeletedPersons(?,?,?))", new object[] { managerId, userId, (int)searchCat }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Decimal, NHibernateUtil.Int32 }));
            else
                crit.Add(Expression.Sql(" prs_Id in (select * from fn_GetAccessiblePersons(?,?,?))", new object[] { managerId, userId, (int)searchCat }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Decimal, NHibernateUtil.Int32 }));


            if (!disjunction.ToString().Equals("()"))
            {
                crit.Add(disjunction);
            }
            if (!integratedSearchDisjunction.ToString().Equals("()"))
            {
                crit.Add(integratedSearchDisjunction);
            }
            if (!Utility.Utility.IsEmpty(crit.ToString()))
            {
                if (pageIndex == 0 && pageSize == 0)
                {
                    list = crit
                        .List<Person>();
                }
                else
                {
                    list = crit
                        .SetFirstResult(pageIndex * pageSize)
                        .SetMaxResults(pageSize)
                        .List<Person>();
                }
            }
            return list;
        }

        public IList<Person> SearchByOperator(PersonSearchProxy proxy, decimal userId, int pageIndex, int pageSize, out int count)
        {
            const string PersonDetailAlias = "prsDtl";
            const string WorkGroupAlias = "wg";
            const string RuleGroupAlias = "rg";
            const string CalculationDateRangeGroupAlias = "cdrg";
            const string DepartmentAlias = "dep";
            const string OrganizationUnitAlias = "organ";
            const string PersonTASpecAlias = "prsTs";
            const string GradeAlias = "grade";
            const string CostCenterAlias = "CostCenter";
            const string EmploymentAlias = "emp";
            count = 0;


            ICriteria crit = base.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            //crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetail), PersonDetailAlias);
            crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetailList), PersonDetailAlias);


            //فعال
            if (proxy.PersonActivateState != null)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Active), (bool)proxy.PersonActivateState));
            }

            //کد پرسنلی
            if (!Utility.Utility.IsEmpty(proxy.PersonCode))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.PersonCode, MatchMode.Anywhere));
            }

            //کد ملی
            if (!Utility.Utility.IsEmpty(proxy.MelliCode))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MeliCode), proxy.MelliCode, MatchMode.Anywhere));
            }

            //نام
            if (!Utility.Utility.IsEmpty(proxy.FirstName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.FirstName, MatchMode.Anywhere));
            }

            //نام خانوادگی
            if (!Utility.Utility.IsEmpty(proxy.LastName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.LastName, MatchMode.Anywhere));
            }

            //نام پدر
            if (!Utility.Utility.IsEmpty(proxy.FatherName))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().FatherName), proxy.FatherName, MatchMode.Anywhere));
            }

            //جنسیت ,پیش فرض آن از واسط کاربر -1 است
            if (!Utility.Utility.IsEmpty(proxy.Sex) && proxy.Sex >= 0)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Sex), proxy.Sex));
            }

            //شماره کارت
            if (!Utility.Utility.IsEmpty(proxy.CartNumber))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.CartNumber));
            }

            //نظام وضیفه , پیش فرض آن از واسط کاربر 0 است
            if (!Utility.Utility.IsEmpty(proxy.Military) && proxy.Military > 0)
            {
                crit.Add(Restrictions.Eq(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MilitaryStatus), proxy.Military));
            }

            //تحصیلات
            if (!Utility.Utility.IsEmpty(proxy.Education))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().Education), proxy.Education, MatchMode.Anywhere));
            }

            //تاهل , پیش فرض آن از واسط کاربر 0 است
            if (!Utility.Utility.IsEmpty(proxy.MaritalStatus) && proxy.MaritalStatus > 0)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().MaritalStatus), proxy.MaritalStatus));
            }

            //شروع تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.FromBirthDate))
            {
                crit.Add(Restrictions.Ge(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.FromBirthDate)));
            }

            //پایان تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.ToBirthDate))
            {
                crit.Add(Restrictions.Le(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.ToBirthDate)));
            }

            //شروع تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.FromEmploymentDate))
            {
                crit.Add(Restrictions.Ge(Utility.Utility.GetPropertyName(() => new Person().EmploymentDate), Utility.Utility.ToMildiDateTime(proxy.FromEmploymentDate)));
            }

            //پایان تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.ToEmploymentDate))
            {
                crit.Add(Restrictions.Le(Utility.Utility.GetPropertyName(() => new Person().EndEmploymentDate), Utility.Utility.ToMildiDateTime(proxy.ToEmploymentDate)));
            }

            //بخش
            //if (!Utility.Utility.IsEmpty(proxy.DepartmentId))
            //{
            //	crit.CreateAlias("department", DepartmentAlias);

            //	if (proxy.IncludeSubDepartments)
            //	{
            //		disjunction.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //		disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + proxy.DepartmentId.ToString() + ",", MatchMode.Anywhere));

            //	}
            //	else
            //	{
            //		crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //	}

            //}
            if (!Utility.Utility.IsEmpty(proxy.DepartmentListId))
            {
                crit.CreateAlias("department", DepartmentAlias);

                if (proxy.IncludeSubDepartments)
                {
                    disjunction.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));

                    foreach (decimal item in proxy.DepartmentListId)
                    {
                        disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + item.ToString() + ",", MatchMode.Anywhere));
                    }


                }
                else
                {

                    crit.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));
                }

            }
            //پست سازمانی
            if (!Utility.Utility.IsEmpty(proxy.OrganizationUnitId))
            {
                crit.CreateAlias("OrganizationUnitList", OrganizationUnitAlias);
                crit.Add(Restrictions.Eq(OrganizationUnitAlias + "." + Utility.Utility.GetPropertyName(() => new OrganizationUnit().ID), (decimal)proxy.OrganizationUnitId));
            }
            //رتبه
            if (!Utility.Utility.IsEmpty(proxy.GradeId))
            {
                crit.CreateAlias("grade", GradeAlias);
                crit.Add(Restrictions.Eq(GradeAlias + "." + Utility.Utility.GetPropertyName(() => new Grade().ID), (decimal)proxy.GradeId));
            }
            //مرکز هزینه
            if (!Utility.Utility.IsEmpty(proxy.CostCenterId))
            {
                crit.CreateAlias("costCenter", CostCenterAlias);
                crit.Add(Restrictions.Eq(CostCenterAlias + "." + Utility.Utility.GetPropertyName(() => new CostCenter().ID), (decimal)proxy.CostCenterId));
            }

            //گروه کاری
            if (!Utility.Utility.IsEmpty(proxy.WorkGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonWorkGroupList), WorkGroupAlias);
                crit.Add(Restrictions.Eq(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().WorkGroup), new WorkGroup() { ID = (decimal)proxy.WorkGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.WorkGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().FromDate), Utility.Utility.ToMildiDateTime(proxy.WorkGroupFromDate)));
                }
            }

            //گروه قوانین
            if (!Utility.Utility.IsEmpty(proxy.RuleGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRuleCatAssignList), RuleGroupAlias);
                crit.Add(Restrictions.Eq(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().RuleCategory), new RuleCategory() { ID = (decimal)proxy.RuleGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.RuleGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().FromDate), Utility.Utility.ToString(proxy.RuleGroupFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().ToDate), Utility.Utility.ToString(proxy.RuleGroupToDate)));
                }
            }

            //محدوده محاسبات
            if (!Utility.Utility.IsEmpty(proxy.CalculationDateRangeId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRangeAssignList), CalculationDateRangeGroupAlias);
                crit.Add(Restrictions.Eq(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().CalcDateRangeGroup), new CalculationRangeGroup() { ID = (decimal)proxy.CalculationDateRangeId }));

                if (!Utility.Utility.IsEmpty(proxy.CalculationFromDate))
                {
                    crit.Add(Restrictions.Ge(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.CalculationFromDate)));
                }
            }

            //ایستگاه کنترل
            //if (!Utility.Utility.IsEmpty(proxy.ControlStationId))
            //{
            //	crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
            //	crit.Add(Restrictions.Eq(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), new ControlStation() { ID = (decimal)proxy.ControlStationId }));
            //	//crit.Add(Restrictions.Eq("controlStation", new ControlStation() { ID = (decimal)proxy.ControlStationId }));
            //}
            if (!Utility.Utility.IsEmpty(proxy.ControlStationListId))
            {
                List<ControlStation> controlStationList = new List<ControlStation>();
                foreach (decimal item in proxy.ControlStationListId)
                {
                    controlStationList.Add(new ControlStation() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), controlStationList));


            }
            //نوع استخدام
            //if (!Utility.Utility.IsEmpty(proxy.EmploymentType))
            //{
            //	crit.Add(Restrictions.Eq("employmentType", new EmploymentType() { ID = (decimal)proxy.EmploymentType }));
            //}
            if (!Utility.Utility.IsEmpty(proxy.EmploymentTypeListId))
            {
                crit.CreateAlias("employmentType", EmploymentAlias);
                crit.Add(Restrictions.In(EmploymentAlias + "." + Utility.Utility.GetPropertyName(() => new EmploymentType().ID), proxy.EmploymentTypeListId.ToArray()));


            }
            //اشخاص مشخص شده
            if (!Utility.Utility.IsEmpty(proxy.PersonIdList))
            {
                crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), CheckListParameter(proxy.PersonIdList)));
            }

            //جستجو در بین مدیران و اپراتورها
            if (proxy.SearchInCategory != PersonCategory.Public
                && !Utility.Utility.IsEmpty(proxy.SearchInCategory))
            {
                if (proxy.SearchInCategory == PersonCategory.Manager)
                {
                    IList<Person> personList = new ManagerRepository(false).GetAllManager();
                    var ids = from person in personList
                              select person.ID;
                    IList<decimal> idList = ids.ToList<decimal>();

                    crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), idList.ToArray()));
                }
            }
            IList<Person> list = new List<Person>();

            crit.Add(Expression.Sql(@" prs_Id in (SELECT Prs_Id FROM
	                                                                (SELECT opr_FlowId
                                                                     FROM TA_Operator     
                                                                     WHERE opr_PersonId = (select user_personid from ta_securityuser where user_ID = ? AND user_Active=1)  
			                                                         AND opr_Active=1
                                                                    ) oprFlow
	                                                                 INNER JOIN (SELECT UndermanagmentsPersons.Prs_Id, Flow.Flow_ID
		                                                             FROM TA_Flow Flow		 
			                                                         CROSS APPLY [dbo].[TA_GetUnderManagmentPersons] (Flow.Flow_ID) as UndermanagmentsPersons
		                                                            ) AS UnderMgn
	                                                                ON oprFlow.opr_FlowId = UnderMgn.Flow_Id
                                                 )", new object[] { userId }, new IType[] { NHibernateUtil.Decimal }));

            if (!disjunction.ToString().Equals("()"))
            {
                crit.Add(disjunction);
            }
            if (!Utility.Utility.IsEmpty(crit.ToString()))
            {
                list = crit.List<Person>();
                count = list.Count();
                list = list.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            return list;
        }


        public IList<Person> Search(string key, decimal userId, decimal managerId, PersonCategory searchCat, int pageSize, int pageIndex)
        {
            string SQLCommand = "";

            SQLCommand = @"SELECT prs.* FROM TA_Person as prs
                                  where prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' 
                                        AND ( prs_BarCode like :searchKey OR
                                        prs_CardNum like :searchKey OR
                                        prs_FirstName + ' ' + prs_LastName like :searchKey)
                                        AND prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
                                        Order by prs_GradeId desc  ";

            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .AddEntity(typeof(Person))
                .SetParameter("searchKey", "%" + key + "%")
                .SetParameter("userId", userId)
                .SetParameter("managerId", managerId)
                .SetParameter("searchCat", (int)searchCat)
                .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize);

            IList<Person> list = new List<Person>();

            list = query.List<Person>();

            return list;
        }

        public IList<Person> SearchMethodBase(string key, decimal userId, decimal managerId, PersonCategory searchCat, int pageSize, int pageIndex)
        {
            string SQLCommand = "";
            TempRepository tempRepository = new TempRepository(false);
            IList<decimal> accessiblePersonIdsList = new List<decimal>();
            IList<Person> personsList = new List<Person>();
            GTS.Clock.Model.Temp.Temp tempAlias = null;
            Person personAlias = null;
            Grade gradeAlias = null;


            SQLCommand = @"select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat)";

            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                                                 .SetParameter("userId", userId)
                                                 .SetParameter("managerId", managerId)
                                                 .SetParameter("searchCat", (int)searchCat);
            accessiblePersonIdsList = query.List<decimal>();

            if (accessiblePersonIdsList.Count < this.operationBatchSizeValue && this.operationBatchSizeValue < 2100)
            {
                personsList = this.NHSession.QueryOver<Person>(() => personAlias)
                                            .Left
                                            .JoinAlias(() => personAlias.ExtGrade, () => gradeAlias)
                                            .Where(() => !personAlias.IsDeleted &&
                                                          personAlias.Active &&
                                                          personAlias.BarCode != "00000000" &&
                                                         (personAlias.BarCode.IsInsensitiveLike(key, MatchMode.Anywhere) ||
                                                          personAlias.CardNum.IsInsensitiveLike(key, MatchMode.Anywhere) ||
                                                          personAlias.FullName.IsInsensitiveLike(key, MatchMode.Anywhere)
                                                         ) &&
                                                          personAlias.ID.IsIn(accessiblePersonIdsList.ToArray())
                                                  )
                                            .OrderBy(() => gradeAlias.ID)
                                            .Desc
                                            .Skip(pageIndex * pageSize)
                                            .Take(pageSize)
                                            .List<Person>();
            }
            else
            {
                string operationGUID = tempRepository.InsertTempList(accessiblePersonIdsList);

                personsList = this.NHSession.QueryOver<Person>(() => personAlias)
                                            .Left
                                            .JoinAlias(() => personAlias.ExtGrade, () => gradeAlias)
                                            .JoinAlias(() => personAlias.TempList, () => tempAlias)
                                            .Where(() => !personAlias.IsDeleted &&
                                                          personAlias.Active &&
                                                          personAlias.BarCode != "00000000" &&
                                                         (personAlias.BarCode.IsInsensitiveLike(key, MatchMode.Anywhere) ||
                                                          personAlias.CardNum.IsInsensitiveLike(key, MatchMode.Anywhere) ||
                                                          personAlias.FullName.IsInsensitiveLike(key, MatchMode.Anywhere)
                                                         ) &&
                                                          tempAlias.OperationGUID == operationGUID
                                                  )
                                            .OrderBy(() => gradeAlias.ID)
                                            .Desc
                                            .Skip(pageIndex * pageSize)
                                            .Take(pageSize)
                                            .List<Person>();

                tempRepository.DeleteTempList(operationGUID);
            }

            return personsList;

        }



        public IList<Person> SearchBySubstitute(decimal personId, string key, decimal userId, decimal managerId, PersonCategory searchCat, int pageSize, int pageIndex)
        {
            string SQLCommand = "";
            SQLCommand = @"select prs.* from ta_person as prs
                           left join TA_Grade as grd
                           on prs.prs_GradeId = grd.Grade_ID
                           inner join TA_Department dep
                           on prs.Prs_DepartmentId = dep.dep_ID
                           where prs.Prs_Id !=:personId and prs.Prs_Active = 1 and prs.prs_IsDeleted = 0 AND prs_BarCode <> '00000000' and
                          (Prs_DepartmentId =(select Prs_DepartmentId from TA_Person where Prs_ID =:personId) or
                           prs_GradeId = (select prs_GradeId from TA_Person where Prs_ID =:personId)                                                                                  
                          )
                           AND ( prs_BarCode like :searchKey OR
                                prs_CardNum like :searchKey OR
                               prs_FirstName + ' ' + prs_LastName like :searchKey)                         
                           ";
            //AND prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
            IList<Person> personList = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                                           .AddEntity(typeof(Person))
                                           .SetParameter("personId", personId)
                                           .SetParameter("searchKey", "%" + key + "%")
                // .SetParameter("userId", userId)
                //.SetParameter("managerId", managerId)
                //.SetParameter("searchCat", (int)searchCat)
                                           .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize)
                                           .List<Person>();
            return personList;


        }
        public IList<Person> SearchByMonthlyExceptionShifts(string key, decimal userId, decimal managerId, PersonCategory searchCat, int pageSize, int pageIndex, IList<DateTime> MonthDatesList)
        {
            string SQLCommand = "";
            SQLCommand = @"SELECT * FROM 
                          (Select prs.* FROM TA_Person as prs
                           Left JOIN TA_Grade as grad
                           ON    prs.prs_GradeId = grad.Grade_ID
                           INNER JOIN TA_ExceptionShift as ExShift                           
                           ON prs.Prs_ID = ExShift.ExceptionShift_PersonID
                           INNER JOIN TA_Shift as shift
                           ON ExShift.ExceptionShift_ShiftID = shift.Shift_ID                          
                           WHERE prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' AND ExceptionShift_Date in (:DateList) AND
                           (prs_BarCode like :searchKey OR                           
                            prs_FirstName + ' ' + prs_LastName like :searchKey OR                            
                            grad.Grade_Name like :searchKey OR
                            Shift_Name like :searchKey OR
                            Shift_CustomCode like :searchKey 
                                       ) AND
                           prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
                           
UNION
                            Select prs.* FROM TA_Person as prs 
                                       Left JOIN TA_Grade as grad
                                       ON    prs.prs_GradeId = grad.Grade_ID
                                       WHERE prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' AND
                                       (prs_BarCode like :searchKey OR                            
                                        prs_FirstName + ' ' + prs_LastName like :searchKey OR
                                        grad.Grade_Name like :searchKey                          
                                       )AND
                           prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))             
                
                            
                           )prsShift
                    Order by prsShift.prs_GradeId desc       
";
            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                 .AddEntity(typeof(Person))
                 .SetParameter("searchKey", "%" + key + "%")
                 .SetParameter("userId", userId)
                 .SetParameter("managerId", managerId)
                 .SetParameter("searchCat", (int)searchCat)
                 .SetParameterList("DateList", MonthDatesList.ToArray())
                 .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize);

            IList<Person> list = new List<Person>();

            list = query.List<Person>();

            return list;


        }

        public IList<Person> IntegratedSearch(string key, string integratedKey, decimal userId, decimal managerId, PersonCategory searchCat, int pageSize, int pageIndex)
        {
            string SQLCommand = "";

            SQLCommand = @"SELECT prs.* FROM TA_Person as prs
                                  where prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' 
                                        AND ( (prs_BarCode like :searchKey AND prs_BarCode like :integratedSearchKey) OR
                                        (prs_CardNum like :searchKey AND prs_CardNum like :integratedSearchKey) OR
                                        (prs_FirstName + ' ' + prs_LastName like :searchKey AND prs_FirstName + ' ' + prs_LastName like :integratedSearchKey))
                                        AND prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
                                        Order by prs_GradeId desc";



            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                               .AddEntity(typeof(Person))
                               .SetParameter("searchKey", "%" + key + "%")
                               .SetParameter("integratedSearchKey", "%" + integratedKey + "%")
                               .SetParameter("userId", userId)
                               .SetParameter("managerId", managerId)
                               .SetParameter("searchCat", (int)searchCat)
                               .SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize);

            IList<Person> list = new List<Person>();

            list = query.List<Person>();

            return list;
        }


        public IList<Person> SearchByOperator(string key, decimal userId, int pageSize, int pageIndex, out int count)
        {
            string SQLCommand = "";
            IList<Person> list = new List<Person>();

            SQLCommand = @"select * from TA_Person prs
                                  where Prs_IsDeleted=0  AND prs_Active=1 AND 
                                        (prs_BarCode like :searchKey OR
                                        prs_CardNum like :searchKey OR
                                        prs_FirstName + ' ' + prs_LastName like :searchKey)
                                        AND prs.prs_BarCode <> '00000000'
                                        AND prs.prs_ID in (SELECT Prs_Id FROM
	                                                                         (SELECT opr_FlowId
                                                                              FROM TA_Operator     
                                                                              WHERE opr_PersonId = (select user_personid from ta_securityuser where user_ID = :userId AND user_Active=1)  
			                                                                        AND opr_Active=1
                                                                             ) oprFlow
	                                                                         INNER JOIN (SELECT UndermanagmentsPersons.Prs_Id, Flow.Flow_ID
		                                                                     FROM TA_Flow Flow		 
			                                                                 CROSS APPLY [dbo].[TA_GetUnderManagmentPersons] (Flow.Flow_ID) as UndermanagmentsPersons
		                                                                     ) AS UnderMgn
	                                                                         ON oprFlow.opr_FlowId = UnderMgn.Flow_Id
            
                                                          )";


            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .AddEntity(typeof(Person))
                .SetParameter("searchKey", "%" + key + "%")
                .SetParameter("userId", userId);
            list = query.List<Person>();

            count = list.Count();
            list = list.Skip(pageIndex * pageSize).Take(pageSize).ToList<Person>();
            return list;
        }


        public IList<Person> Search(string key, decimal userId, decimal managerId, PersonCategory searchCat)
        {
            string SQLCommand = "";

            SQLCommand = @"SELECT prs.* FROM TA_Person as prs
                                  where prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' 
                                        AND ( prs_BarCode like :searchKey OR
                                        prs_CardNum like :searchKey OR
                                        prs_FirstName + ' ' + prs_LastName like :searchKey)
                                        AND prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))";

            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .AddEntity(typeof(Person))
                .SetParameter("searchKey", "%" + key + "%")
                .SetParameter("userId", userId)
                .SetParameter("managerId", managerId)
                .SetParameter("searchCat", (int)searchCat);

            IList<Person> list = new List<Person>();

            list = query.List<Person>();

            return list;
        }

        public int SearchCount(PersonSearchProxy proxy, decimal userId, decimal managerId, PersonCategory searchCat)
        {
            const string PersonDetailAlias = "prsDtl";
            const string WorkGroupAlias = "wg";
            const string RuleGroupAlias = "rg";
            const string CalculationDateRangeGroupAlias = "cdrg";
            const string DepartmentAlias = "dep";
            const string OrganizationUnitAlias = "organ";
            const string PersonTASpecAlias = "prsTs";
            const string EmploymentAlias = "emp";
            const string ContractAlias = "con";
            const string GradeAlias = "grade";
            const string CostCenterAlias = "CostCenter";

            ICriteria crit = base.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            Junction integratedSearchDisjunction = Restrictions.Disjunction();
            //crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetail), PersonDetailAlias);
            crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetailList), PersonDetailAlias);
            // crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));
            //حذف شده
            if (proxy.PersonIsDeleted == true)
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), (bool)proxy.PersonIsDeleted));
            else
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            }
            //فعال
            if (proxy.PersonActivateState != null)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Active), (bool)proxy.PersonActivateState));
            }
            //کد پرسنلی
            if (!Utility.Utility.IsEmpty(proxy.PersonCode))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.PersonCode, MatchMode.Anywhere));
            }

            //کد ملی
            if (!Utility.Utility.IsEmpty(proxy.MelliCode))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MeliCode), proxy.MelliCode, MatchMode.Anywhere));
            }

            //نام
            if (!Utility.Utility.IsEmpty(proxy.FirstName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.FirstName, MatchMode.Anywhere));
            }

            //نام خانوادگی
            if (!Utility.Utility.IsEmpty(proxy.LastName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.LastName, MatchMode.Anywhere));
            }

            //نام پدر
            if (!Utility.Utility.IsEmpty(proxy.FatherName))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().FatherName), proxy.FatherName, MatchMode.Anywhere));
            }

            //جنسیت
            if (!Utility.Utility.IsEmpty(proxy.Sex))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Sex), proxy.Sex));
            }

            //شروع تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.FromBirthDate))
            {
                crit.Add(Restrictions.Ge(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.FromBirthDate)));
            }

            //پایان تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.ToBirthDate))
            {
                crit.Add(Restrictions.Le(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.ToBirthDate)));
            }

            //شروع تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.FromEmploymentDate))
            {
                crit.Add(Restrictions.Ge(Utility.Utility.GetPropertyName(() => new Person().EmploymentDate), Utility.Utility.ToMildiDateTime(proxy.FromEmploymentDate)));
            }

            //پایان تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.ToEmploymentDate))
            {
                crit.Add(Restrictions.Le(Utility.Utility.GetPropertyName(() => new Person().EndEmploymentDate), Utility.Utility.ToMildiDateTime(proxy.ToEmploymentDate)));
            }

            //شماره کارت
            if (!Utility.Utility.IsEmpty(proxy.CartNumber))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.CartNumber));
            }

            //نظام وضیفه
            if (!Utility.Utility.IsEmpty(proxy.Military))
            {
                crit.Add(Restrictions.Eq(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MilitaryStatus), proxy.Military));
            }

            //تحصیلات
            if (!Utility.Utility.IsEmpty(proxy.Education))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().Education), proxy.Education, MatchMode.Anywhere));
            }

            //تاهل
            if (!Utility.Utility.IsEmpty(proxy.MaritalStatus))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().MaritalStatus), proxy.MaritalStatus));
            }

            //بخش
            //if (!Utility.Utility.IsEmpty(proxy.DepartmentId))
            //{
            //    crit.CreateAlias("department", DepartmentAlias);

            //    if (proxy.IncludeSubDepartments)
            //    {
            //        disjunction.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //        disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + proxy.DepartmentId.ToString() + ",", MatchMode.Anywhere));

            //    }
            //    else
            //    {
            //        crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //    }

            //}
            if (!Utility.Utility.IsEmpty(proxy.DepartmentListId))
            {
                crit.CreateAlias("department", DepartmentAlias);

                if (proxy.IncludeSubDepartments)
                {
                    disjunction.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));

                    foreach (decimal item in proxy.DepartmentListId)
                    {
                        disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + item.ToString() + ",", MatchMode.Anywhere));
                    }


                }
                else
                {

                    crit.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));
                }

            }
            //پست سازمانی
            if (!Utility.Utility.IsEmpty(proxy.OrganizationUnitId))
            {
                crit.CreateAlias("OrganizationUnitList", OrganizationUnitAlias);
                crit.Add(Restrictions.Eq(OrganizationUnitAlias + "." + Utility.Utility.GetPropertyName(() => new OrganizationUnit().ID), (decimal)proxy.OrganizationUnitId));
            }

            //گروه کاری
            if (!Utility.Utility.IsEmpty(proxy.WorkGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonWorkGroupList), WorkGroupAlias);
                crit.Add(Restrictions.Eq(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().WorkGroup), new WorkGroup() { ID = (decimal)proxy.WorkGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.WorkGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().FromDate), Utility.Utility.ToMildiDateTime(proxy.WorkGroupFromDate)));
                }
            }

            //گروه قوانین
            if (!Utility.Utility.IsEmpty(proxy.RuleGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRuleCatAssignList), RuleGroupAlias);
                crit.Add(Restrictions.Eq(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().RuleCategory), new RuleCategory() { ID = (decimal)proxy.RuleGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.RuleGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().FromDate), Utility.Utility.ToString(proxy.RuleGroupFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().ToDate), Utility.Utility.ToString(proxy.RuleGroupToDate)));
                }
            }
            //گروه قوانین واسط کاربری
            if (!Utility.Utility.IsEmpty(proxy.UiValidationGroupID))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.Eq(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().UIValidationGroup), new UIValidationGroup() { ID = (decimal)proxy.UiValidationGroupID }));
            }
            //محدوده محاسبات
            if (!Utility.Utility.IsEmpty(proxy.CalculationDateRangeId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRangeAssignList), CalculationDateRangeGroupAlias);
                crit.Add(Restrictions.Eq(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().CalcDateRangeGroup), new CalculationRangeGroup() { ID = (decimal)proxy.CalculationDateRangeId }));

                if (!Utility.Utility.IsEmpty(proxy.CalculationFromDate))
                {
                    crit.Add(Restrictions.Ge(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.CalculationFromDate)));
                }
            }

            //ایستگاه کنترل
            if (!Utility.Utility.IsEmpty(proxy.ControlStationListId))
            {
                List<ControlStation> controlStationList = new List<ControlStation>();
                foreach (decimal item in proxy.ControlStationListId)
                {
                    controlStationList.Add(new ControlStation() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), controlStationList));


            }
            //رتبه
            if (!Utility.Utility.IsEmpty(proxy.GradeId))
            {
                crit.CreateAlias("grade", GradeAlias);
                crit.Add(Restrictions.Eq(GradeAlias + "." + Utility.Utility.GetPropertyName(() => new Grade().ID), (decimal)proxy.GradeId));
            }
            //مرکز هزینه
            if (!Utility.Utility.IsEmpty(proxy.CostCenterId))
            {
                crit.CreateAlias("costCenter", CostCenterAlias);
                crit.Add(Restrictions.Eq(CostCenterAlias + "." + Utility.Utility.GetPropertyName(() => new CostCenter().ID), (decimal)proxy.CostCenterId));
            }

            //نوع استخدام
            if (!Utility.Utility.IsEmpty(proxy.EmploymentTypeListId))
            {
                crit.CreateAlias("employmentType", EmploymentAlias);
                crit.Add(Restrictions.In(EmploymentAlias + "." + Utility.Utility.GetPropertyName(() => new EmploymentType().ID), proxy.EmploymentTypeListId.ToArray()));


            }
            // گروه واسط کاربری
            if (!Utility.Utility.IsEmpty(proxy.UIValidationGroupListId))
            {
                List<UIValidationGroup> uiValidationGroupList = new List<UIValidationGroup>();
                foreach (decimal item in proxy.UIValidationGroupListId)
                {
                    uiValidationGroupList.Add(new UIValidationGroup() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().UIValidationGroup), uiValidationGroupList));
            }
            //قرارداد
            if (!Utility.Utility.IsEmpty(proxy.ContractId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonContractAssignmentList), ContractAlias);
                crit.Add(Restrictions.Eq(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().Contract), new Contract() { ID = (decimal)proxy.ContractId }));
                crit.Add(Restrictions.Eq(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().IsDeleted), false));
                if (!Utility.Utility.IsEmpty(proxy.ContractFromDate))
                {
                    crit.Add(Restrictions.Ge(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.ContractFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(ContractAlias + "." + Utility.Utility.GetPropertyName(() => new PersonContractAssignment().ToDate), Utility.Utility.ToMildiDateTime(proxy.ContractToDate)));
                }
            }
            //جستجو در بین مدیران و اپراتورها
            if (proxy.SearchInCategory != PersonCategory.Public
                && !Utility.Utility.IsEmpty(proxy.SearchInCategory))
            {
                if (proxy.SearchInCategory == PersonCategory.Manager)
                {
                    IList<Person> personList = new ManagerRepository(false).GetAllManager();
                    var ids = from person in personList
                              select person.ID;
                    IList<decimal> idList = ids.ToList<decimal>();

                    crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), idList.ToArray()));
                }
            }

            if (!Utility.Utility.IsEmpty(proxy.IntegratedSearchTerm))
            {
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
                integratedSearchDisjunction.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.IntegratedSearchTerm, MatchMode.Anywhere));
            }
            if (proxy.PersonIsDeleted == true)
                crit.Add(Expression.Sql(" prs_Id in (select * from fn_GetAccessibleDeletedPersons(?,?,?))", new object[] { managerId, userId, (int)searchCat }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Decimal, NHibernateUtil.Int32 }));
            else
                crit.Add(Expression.Sql(" prs_Id in (select * from fn_GetAccessiblePersons(?,?,?))", new object[] { managerId, userId, (int)searchCat }, new IType[] { NHibernateUtil.Decimal, NHibernateUtil.Decimal, NHibernateUtil.Int32 }));
            if (!disjunction.ToString().Equals("()"))
            {
                crit.Add(disjunction);
            }
            if (!integratedSearchDisjunction.ToString().Equals("()"))
            {
                crit.Add(integratedSearchDisjunction);
            }
            crit.SetProjection(Projections.Count(Utility.Utility.GetPropertyName(() => new Person().ID)));
            if (!Utility.Utility.IsEmpty(crit.ToString()))
            {
                object count = crit.UniqueResult();
                return (int)count;
            }
            return 0;
        }

        public int SearchCountByOperator(PersonSearchProxy proxy, decimal userId)
        {
            const string PersonDetailAlias = "prsDtl";
            const string WorkGroupAlias = "wg";
            const string RuleGroupAlias = "rg";
            const string CalculationDateRangeGroupAlias = "cdrg";
            const string DepartmentAlias = "dep";
            const string OrganizationUnitAlias = "organ";
            const string PersonTASpecAlias = "prsTs";
            const string EmploymentAlias = "emp";
            const string GradeAlias = "grade";
            const string CostCenterAlias = "CostCenter";

            ICriteria crit = base.NHibernateSession.CreateCriteria(typeof(Person));
            Junction disjunction = Restrictions.Disjunction();
            //crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetail), PersonDetailAlias);
            crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonDetailList), PersonDetailAlias);
            crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().IsDeleted), false));
            crit.Add(Restrictions.Not(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().BarCode), "00000000")));

            //فعال
            if (proxy.PersonActivateState != null)
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Active), (bool)proxy.PersonActivateState));
            }

            //کد پرسنلی
            if (!Utility.Utility.IsEmpty(proxy.PersonCode))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().BarCode), proxy.PersonCode, MatchMode.Anywhere));
            }

            //کد ملی
            if (!Utility.Utility.IsEmpty(proxy.MelliCode))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MeliCode), proxy.MelliCode, MatchMode.Anywhere));
            }

            //نام
            if (!Utility.Utility.IsEmpty(proxy.FirstName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().FirstName), proxy.FirstName, MatchMode.Anywhere));
            }

            //نام خانوادگی
            if (!Utility.Utility.IsEmpty(proxy.LastName))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().LastName), proxy.LastName, MatchMode.Anywhere));
            }

            //نام پدر
            if (!Utility.Utility.IsEmpty(proxy.FatherName))
            {
                crit.Add(Restrictions.Like(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().FatherName), proxy.FatherName, MatchMode.Anywhere));
            }

            //جنسیت
            if (!Utility.Utility.IsEmpty(proxy.Sex))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Sex), proxy.Sex));
            }

            //شروع تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.FromBirthDate))
            {
                crit.Add(Restrictions.Ge(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.FromBirthDate)));
            }

            //پایان تاریخ تولد
            if (!Utility.Utility.IsEmpty(proxy.ToBirthDate))
            {
                crit.Add(Restrictions.Le(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().BirthDate), Utility.Utility.ToMildiDateTime(proxy.ToBirthDate)));
            }

            //شروع تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.FromEmploymentDate))
            {
                crit.Add(Restrictions.Ge(Utility.Utility.GetPropertyName(() => new Person().EmploymentDate), Utility.Utility.ToMildiDateTime(proxy.FromEmploymentDate)));
            }

            //پایان تاریخ استخدام
            if (!Utility.Utility.IsEmpty(proxy.ToEmploymentDate))
            {
                crit.Add(Restrictions.Le(Utility.Utility.GetPropertyName(() => new Person().EndEmploymentDate), Utility.Utility.ToMildiDateTime(proxy.ToEmploymentDate)));
            }

            //شماره کارت
            if (!Utility.Utility.IsEmpty(proxy.CartNumber))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().CardNum), proxy.CartNumber));
            }

            //نظام وضیفه
            if (!Utility.Utility.IsEmpty(proxy.Military))
            {
                crit.Add(Restrictions.Eq(PersonDetailAlias + "." + Utility.Utility.GetPropertyName(() => new PersonDetail().MilitaryStatus), proxy.Military));
            }

            //تحصیلات
            if (!Utility.Utility.IsEmpty(proxy.Education))
            {
                crit.Add(Restrictions.Like(Utility.Utility.GetPropertyName(() => new Person().Education), proxy.Education, MatchMode.Anywhere));
            }

            //تاهل
            if (!Utility.Utility.IsEmpty(proxy.MaritalStatus))
            {
                crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().MaritalStatus), proxy.MaritalStatus));
            }

            //بخش
            //if (!Utility.Utility.IsEmpty(proxy.DepartmentId))
            //{
            //	crit.CreateAlias("department", DepartmentAlias);

            //	if (proxy.IncludeSubDepartments)
            //	{
            //		disjunction.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //		disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + proxy.DepartmentId.ToString() + ",", MatchMode.Anywhere));

            //	}
            //	else
            //	{
            //		crit.Add(Restrictions.Eq(Utility.Utility.GetPropertyName(() => new Person().Department).ToLower(), new Department() { ID = (decimal)proxy.DepartmentId }));
            //	}

            //}
            if (!Utility.Utility.IsEmpty(proxy.DepartmentListId))
            {
                crit.CreateAlias("department", DepartmentAlias);

                if (proxy.IncludeSubDepartments)
                {
                    disjunction.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));

                    foreach (decimal item in proxy.DepartmentListId)
                    {
                        disjunction.Add(Restrictions.Like(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ParentPath), "," + item.ToString() + ",", MatchMode.Anywhere));
                    }


                }
                else
                {

                    crit.Add(Restrictions.In(DepartmentAlias + "." + Utility.Utility.GetPropertyName(() => new Department().ID), proxy.DepartmentListId.ToArray()));
                }

            }
            //رتبه
            if (!Utility.Utility.IsEmpty(proxy.GradeId))
            {
                crit.CreateAlias("grade", GradeAlias);
                crit.Add(Restrictions.Eq(GradeAlias + "." + Utility.Utility.GetPropertyName(() => new Grade().ID), (decimal)proxy.GradeId));
            }
            //مرکز هزینه
            if (!Utility.Utility.IsEmpty(proxy.CostCenterId))
            {
                crit.CreateAlias("costCenter", CostCenterAlias);
                crit.Add(Restrictions.Eq(CostCenterAlias + "." + Utility.Utility.GetPropertyName(() => new CostCenter().ID), (decimal)proxy.CostCenterId));
            }
            //پست سازمانی
            if (!Utility.Utility.IsEmpty(proxy.OrganizationUnitId))
            {
                crit.CreateAlias("OrganizationUnitList", OrganizationUnitAlias);
                crit.Add(Restrictions.Eq(OrganizationUnitAlias + "." + Utility.Utility.GetPropertyName(() => new OrganizationUnit().ID), (decimal)proxy.OrganizationUnitId));
            }

            //گروه کاری
            if (!Utility.Utility.IsEmpty(proxy.WorkGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonWorkGroupList), WorkGroupAlias);
                crit.Add(Restrictions.Eq(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().WorkGroup), new WorkGroup() { ID = (decimal)proxy.WorkGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.WorkGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(WorkGroupAlias + "." + Utility.Utility.GetPropertyName(() => new AssignWorkGroup().FromDate), Utility.Utility.ToMildiDateTime(proxy.WorkGroupFromDate)));
                }
            }

            //گروه قوانین
            if (!Utility.Utility.IsEmpty(proxy.RuleGroupId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRuleCatAssignList), RuleGroupAlias);
                crit.Add(Restrictions.Eq(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().RuleCategory), new RuleCategory() { ID = (decimal)proxy.RuleGroupId }));

                if (!Utility.Utility.IsEmpty(proxy.RuleGroupFromDate))
                {
                    crit.Add(Restrictions.Ge(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().FromDate), Utility.Utility.ToString(proxy.RuleGroupFromDate)));
                }
                if (!Utility.Utility.IsEmpty(proxy.RuleGroupToDate))
                {
                    crit.Add(Restrictions.Le(RuleGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRuleCatAssignment().ToDate), Utility.Utility.ToString(proxy.RuleGroupToDate)));
                }
            }

            //محدوده محاسبات
            if (!Utility.Utility.IsEmpty(proxy.CalculationDateRangeId))
            {
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonRangeAssignList), CalculationDateRangeGroupAlias);
                crit.Add(Restrictions.Eq(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().CalcDateRangeGroup), new CalculationRangeGroup() { ID = (decimal)proxy.CalculationDateRangeId }));

                if (!Utility.Utility.IsEmpty(proxy.CalculationFromDate))
                {
                    crit.Add(Restrictions.Ge(CalculationDateRangeGroupAlias + "." + Utility.Utility.GetPropertyName(() => new PersonRangeAssignment().FromDate), Utility.Utility.ToMildiDateTime(proxy.CalculationFromDate)));
                }
            }

            //ایستگاه کنترل
            //if (!Utility.Utility.IsEmpty(proxy.ControlStationId))
            //{
            //	crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
            //	crit.Add(Restrictions.Eq(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), new ControlStation() { ID = (decimal)proxy.ControlStationId }));
            //	//crit.Add(Restrictions.Eq("controlStation", new ControlStation() { ID = (decimal)proxy.ControlStationId }));
            //}
            if (!Utility.Utility.IsEmpty(proxy.ControlStationListId))
            {
                List<ControlStation> controlStationList = new List<ControlStation>();
                foreach (decimal item in proxy.ControlStationListId)
                {
                    controlStationList.Add(new ControlStation() { ID = item });
                }
                crit.CreateAlias(Utility.Utility.GetPropertyName(() => new Person().PersonTASpecList), PersonTASpecAlias);
                crit.Add(Restrictions.In(PersonTASpecAlias + "." + Utility.Utility.GetPropertyName(() => new PersonTASpec().ControlStation), controlStationList));


            }

            //نوع استخدام
            //if (!Utility.Utility.IsEmpty(proxy.EmploymentType))
            //{
            //	crit.Add(Restrictions.Eq("employmentType", new EmploymentType() { ID = (decimal)proxy.EmploymentType }));
            //}
            if (!Utility.Utility.IsEmpty(proxy.EmploymentTypeListId))
            {
                crit.CreateAlias("employmentType", EmploymentAlias);
                crit.Add(Restrictions.In(EmploymentAlias + "." + Utility.Utility.GetPropertyName(() => new EmploymentType().ID), proxy.EmploymentTypeListId.ToArray()));


            }

            //جستجو در بین مدیران و اپراتورها
            if (proxy.SearchInCategory != PersonCategory.Public
                && !Utility.Utility.IsEmpty(proxy.SearchInCategory))
            {
                if (proxy.SearchInCategory == PersonCategory.Manager)
                {
                    IList<Person> personList = new ManagerRepository(false).GetAllManager();
                    var ids = from person in personList
                              select person.ID;
                    IList<decimal> idList = ids.ToList<decimal>();

                    crit.Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), idList.ToArray()));
                }
            }
            crit.Add(Expression.Sql(@" prs_Id in (SELECT Prs_Id FROM
	                                                                (SELECT opr_FlowId
                                                                     FROM TA_Operator     
                                                                     WHERE opr_PersonId = (select user_personid from ta_securityuser where user_ID = ? AND user_Active=1)  
			                                                         AND opr_Active=1
                                                                    ) oprFlow
	                                                                 INNER JOIN (SELECT UndermanagmentsPersons.Prs_Id, Flow.Flow_ID
		                                                             FROM TA_Flow Flow		 
			                                                         CROSS APPLY [dbo].[TA_GetUnderManagmentPersons] (Flow.Flow_ID) as UndermanagmentsPersons
		                                                            ) AS UnderMgn
	                                                                ON oprFlow.opr_FlowId = UnderMgn.Flow_Id
                                                 )", new object[] { userId }, new IType[] { NHibernateUtil.Decimal }));
            if (!disjunction.ToString().Equals("()"))
            {
                crit.Add(disjunction);
            }
            crit.SetProjection(Projections.Count(Utility.Utility.GetPropertyName(() => new Person().ID)));
            if (!Utility.Utility.IsEmpty(crit.ToString()))
            {
                object count = crit.UniqueResult();
                return (int)count;
            }
            return 0;
        }


        public int SearchCount(string key, decimal userId, decimal managerId, PersonCategory searchCat)
        {
            string SQLCommand = "";

            SQLCommand = @"select count(prs_ID) from TA_Person prs
                                  where Prs_IsDeleted=0  AND prs_Active=1 AND 
                                        (prs_BarCode like :searchKey OR
                                        prs_CardNum like :searchKey OR
                                        prs_FirstName + ' ' + prs_LastName like :searchKey)
                                        AND prs.prs_BarCode <> '00000000'
                                        AND prs.prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))";


            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .SetParameter("searchKey", "%" + key + "%")
                .SetParameter("userId", userId)
                .SetParameter("managerId", managerId)
                .SetParameter("searchCat", (int)searchCat);
            object count = query.List<object>().First();
            return Utility.Utility.ToInteger(count.ToString());
        }
        public int SearchCountBySubstitute(decimal personId, string key, decimal userId, decimal managerId, PersonCategory searchCat)
        {
            string SQLCommand = "";
            SQLCommand = @"select count(*) from ta_person as prs
                           left join TA_Grade as grd
                           on prs.prs_GradeId = grd.Grade_ID
                           inner join TA_Department dep
                           on prs.Prs_DepartmentId = dep.dep_ID
                           where  prs.Prs_Id !=:personId and prs.Prs_Active = 1 and prs.prs_IsDeleted = 0 AND prs_BarCode <> '00000000' and
                          (Prs_DepartmentId =(select Prs_DepartmentId from TA_Person where Prs_ID =:personId) or
                           prs_GradeId = (select prs_GradeId from TA_Person where Prs_ID =:personId) 
                          )  
                           AND ( prs_BarCode like :searchKey OR
                           prs_CardNum like :searchKey OR
                           prs_FirstName + ' ' + prs_LastName like :searchKey)                          
                          
                          ";
            // AND prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))                                                                               
            object count = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                               .SetParameter("personId", personId)
                               .SetParameter("searchKey", "%" + key + "%")
                // .SetParameter("userId", userId)
                //.SetParameter("managerId", managerId)
                //.SetParameter("searchCat", (int)searchCat)                                           
                               .List<object>().First();
            return Utility.Utility.ToInteger(count.ToString());


        }
        public int SearchCountByMonthlyExceptionShift(string key, decimal userId, decimal managerId, PersonCategory searchCat, IList<DateTime> MonthDatesList)
        {
            string SQLCommand = "";
            SQLCommand = @"SELECT count(*) FROM 
                          (Select prs_ID FROM TA_Person as prs
                           Left JOIN TA_Grade as grad
                           ON    prs.prs_GradeId = grad.Grade_ID
                           INNER JOIN TA_ExceptionShift as ExShift                           
                           ON prs.Prs_ID = ExShift.ExceptionShift_PersonID
                           INNER JOIN TA_Shift as shift
                           ON ExShift.ExceptionShift_ShiftID = shift.Shift_ID                         
                           WHERE prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' AND ExceptionShift_Date in (:DateList) AND
                           (prs_BarCode like :searchKey OR                           
                            prs_FirstName + ' ' + prs_LastName like :searchKey OR                            
                            grad.Grade_Name like :searchKey OR
                            Shift_Name like :searchKey OR
                            Shift_CustomCode like :searchKey 
                                       ) AND
                           prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
UNION
                            Select prs_ID FROM TA_Person as prs 
                                       Left JOIN TA_Grade as grad
                                       ON    prs.prs_GradeId = grad.Grade_ID
                                       WHERE prs_IsDeleted=0 AND prs_Active=1 AND prs_BarCode <> '00000000' AND
                                       (prs_BarCode like :searchKey OR                                                      
                                        prs_FirstName + ' ' + prs_LastName like :searchKey OR
                                        grad.Grade_Name like :searchKey                           
                                       ) AND
                                       prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))
                                      
                           )prsShift";


            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                 .SetParameter("searchKey", "%" + key + "%")
                 .SetParameter("userId", userId)
                 .SetParameter("managerId", managerId)
                 .SetParameter("searchCat", (int)searchCat)
                 .SetParameterList("DateList", MonthDatesList.ToArray());
            object count = query.List<object>().First();
            return Utility.Utility.ToInteger(count.ToString());
        }

        public int IntegratedSearchCount(string key, string integratedKey, decimal userId, decimal managerId, PersonCategory searchCat)
        {
            string SQLCommand = "";

            SQLCommand = @"select count(prs_ID) from TA_Person prs
                                  where Prs_IsDeleted=0  AND prs_Active=1 AND 
                                        ((prs_BarCode like :searchKey AND prs_BarCode like :integratedSearchKey)  OR
                                        (prs_CardNum like :searchKey AND prs_CardNum like :integratedSearchKey) OR
                                        (prs_FirstName + ' ' + prs_LastName like :searchKey AND prs_FirstName + ' ' + prs_LastName like :integratedSearchKey))
                                        AND prs.prs_BarCode <> '00000000'
                                        AND prs.prs_ID in (select * from fn_GetAccessiblePersons(:managerId,:userId,:searchCat))";


            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                                                 .SetParameter("searchKey", "%" + key + "%")
                                                 .SetParameter("integratedSearchKey", "%" + integratedKey + "%")
                                                 .SetParameter("userId", userId)
                                                 .SetParameter("managerId", managerId)
                                                 .SetParameter("searchCat", (int)searchCat);
            object count = query.List<object>().First();
            return Utility.Utility.ToInteger(count.ToString());
        }


        public int SearchCountByOperator(string key, decimal userId)
        {
            string SQLCommand = "";

            SQLCommand = @"select count(prs_ID) from TA_Person prs
                                  where Prs_IsDeleted=0  AND prs_Active=1 AND 
                                        (prs_BarCode like :searchKey OR
                                        prs_CardNum like :searchKey OR
                                        prs_FirstName + ' ' + prs_LastName like :searchKey)
                                        AND prs.prs_BarCode <> '00000000'
                                        AND prs.prs_ID in (SELECT Prs_Id FROM
	                                                                         (SELECT opr_FlowId
                                                                              FROM TA_Operator     
                                                                              WHERE opr_PersonId = (select user_personid from ta_securityuser where user_ID = :userId AND user_Active=1)  
			                                                                        AND opr_Active=1
                                                                             ) oprFlow
	                                                                         INNER JOIN (SELECT UndermanagmentsPersons.Prs_Id, Flow.Flow_ID
		                                                                     FROM TA_Flow Flow		 
			                                                                 CROSS APPLY [dbo].[TA_GetUnderManagmentPersons] (Flow.Flow_ID) as UndermanagmentsPersons
		                                                                     ) AS UnderMgn
	                                                                         ON oprFlow.opr_FlowId = UnderMgn.Flow_Id
                                                          )";
            IQuery query = base.NHibernateSession.CreateSQLQuery(SQLCommand)
                .SetParameter("searchKey", "%" + key + "%")
                .SetParameter("userId", userId);
            object count = query.List<object>().First();
            return Utility.Utility.ToInteger(count.ToString());
        }


        #endregion

        public int GetTestData(string[] ids)
        {
            string SQLQuery = " SELECT count(*) FROM TA_Person WHERE prs_ID in (" + string.Join(",", ids) + ")";

            int count = base.NHibernateSession.CreateSQLQuery(SQLQuery)
                .List<int>().First();
            return count;
        }

        public void TEST(decimal userId)
        {
            try
            {
                Person personAlias = null;
                IQueryOver<Person, Person> PersonIqueryOver = null;
                //PersonIqueryOver = base.NHibernateSession.QueryOver<Person>().Where(()=> personAlias.BarCode == "");
                //PersonIqueryOver=PersonIqueryOver.Where(()=>personAlias.Active==true);
                //PersonIqueryOver.Skip(2*10)
                //                .Take(10)
                //                .List();

                const string PersonDetailAlias = "prsDtl";
                const string WorkGroupAlias = "wg";
                const string RuleGroupAlias = "rg";
                const string CalculationDateRangeGroupAlias = "cdrg";
                const string DepartmentAlias = "dep";
                const string OrganizationUnitAlias = "organ";

                ICriteria crit = base.NHibernateSession.CreateCriteria(typeof(Person));

                crit.Add(Expression.Sql("prs_Id in (select * from fn_GetAccessiblePersons(?))", 1, NHibernateUtil.Decimal));



                crit.SetProjection(Projections.Count(Utility.Utility.GetPropertyName(() => new Person().ID)));
                if (!Utility.Utility.IsEmpty(crit.ToString()))
                {
                    object count = crit.UniqueResult();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                int a = 0;
            }
        }

        public void DeletePersonnelImage(string path)
        {
            if (path != null && path != string.Empty && File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// Sysnc the Time Atendance System Persons with General system
        /// </summary>
        public void SyncPersonTASpec()
        {
            string SQLCommand = @"INSERT INTO TA_PersonTASpec(prsTA_ID,prsTA_Active)
                                    SELECT Prs_ID,Prs_Active FROM TA_Person 
                                    WHERE prs_IsDeleted=0 
                                    AND Prs_ID NOT IN (SELECT prsTA_ID FROM TA_PersonTASpec)";
            base.RunSQL(SQLCommand);
        }

        public bool CheckIsControlStationInUseByPerson(ControlStation controlStation)
        {
            bool isInUse = false;
            int count = 0;
            count = NHibernateSession.QueryOver<PersonTASpec>()
                                     .JoinQueryOver<ControlStation>(pts => pts.ControlStation)
                                     .Where(c => c.ID == controlStation.ID)
                                     .RowCount();
            if (count > 0)
                isInUse = true;
            return isInUse;
        }

        public bool CheckIsUIValidationGroupInUse(UIValidationGroup uiValidationGroup)
        {
            bool isInUse = false;
            int count = 0;

            count = NHibernateSession.QueryOver<PersonTASpec>()
                                     .JoinQueryOver<UIValidationGroup>(pts => pts.UIValidationGroup)
                                     .Where(c => c.ID == uiValidationGroup.ID)
                                     .RowCount();
            if (count > 0)
            {
                PersonTASpec personTAAlias = null;
                Person PersonAlias = null;
                UIValidationGroup uiValidationGroupAlias = null;
                IList<decimal> PersonTASpecIdList = NHibernateSession.QueryOver(() => personTAAlias)
                                                                     .JoinAlias(() => personTAAlias.UIValidationGroup, () => uiValidationGroupAlias)
                                                                     .Where(() => uiValidationGroupAlias.ID == uiValidationGroup.ID)
                                                                     .Select(x => x.ID)
                                                                     .List<decimal>();
                if (PersonTASpecIdList.Count != 0)
                {
                    IList<Person> personList = NHibernateSession.QueryOver(() => PersonAlias)
                                                             .Where(() => PersonAlias.ID.IsIn(PersonTASpecIdList.ToArray()) &&
                                                                          PersonAlias.Active &&
                                                                          !PersonAlias.IsDeleted
                                                                   )
                                                             .List<Person>();
                    if (personList.Count > 0)
                        isInUse = true;
                }
            }
            return isInUse;
        }

        public IList<Person> GetPersonByPersonIdList(IList<decimal> personIdList)
        {
            IList<Person> PersonList = this.NHibernateSession.CreateCriteria<Person>()
                                                             .Add(Restrictions.In(Utility.Utility.GetPropertyName(() => new Person().ID), personIdList.ToArray()))
                                                             .List<Person>();
            return PersonList;
        }

        public IQueryOver<Person, Person> GetPersonByDepartmentId(decimal departmentId)
        {
            Department departmentAlias = null;
            Person personAlias = null;

            return NHibernateSession.QueryOver(() => personAlias)
                                     .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                     .Where(() =>
                                                 personAlias.IsDeleted != true &&
                                                 personAlias.Active == true &&
                                                 (
                                                    departmentAlias.ID == departmentId ||
                                                    departmentAlias.ParentPath.IsLike("," + departmentId.ToString() + ",", MatchMode.Anywhere))
                                                 );
        }

        public IQueryOver<Person, Person> GetPersonByDirectDepartmentId(decimal departmentId)
        {
            Department departmentAlias = null;
            Person personAlias = null;

            return NHibernateSession.QueryOver(() => personAlias)
                                     .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                     .Where(() =>
                                                 personAlias.IsDeleted != true &&
                                                 personAlias.Active == true &&
                                                  departmentAlias.ID == departmentId
                                          );
        }

        /// <summary>
        /// اطلاعات اضافی یک پرسنل را بر می گرداند 
        /// </summary>
        /// <param name="personID">کلید پرسنل</param>
        /// <returns>آبجکت اطلاعات اضافی</returns>
        public PersonTASpec GetPersonTASpecByID(decimal personID)
        {
            PersonTASpec personTASpec = NHibernateSession.QueryOver<PersonTASpec>()
                                                         .Where(x => x.ID == personID)
                                                         .SingleOrDefault();
            return personTASpec;
        }

        /// <summary>
        ///لیست اطلاعات اضافی یک پرسنل را بر می گرداند  
        /// </summary>
        /// <returns>لیست اطلاعات اضافی </returns>
        public IList<PersonTASpec> GetTASpecList()
        {
            IList<PersonTASpec> personTASpecList = NHibernateSession.QueryOver<PersonTASpec>().List();
            return personTASpecList;
        }

        public IList<PersonTASpec> GetTASpecByPersonIdList(IList<decimal> personIdList)
        {
            IList<PersonTASpec> personTASpecList = NHibernateSession.QueryOver<PersonTASpec>()
                .Where(c => c.ID.IsIn(personIdList.ToList()))
                .List();
            return personTASpecList;
        }

        /// <summary>
        /// حذف اطلاعات اضافی در هنگام درج
        /// Create Working
        /// </summary>
        public void DeleteExtraRecordFromDB()
        {
            string SQLCommand = @"
declare @daycount int
set @daycount=3

DELETE FROM CL_PersonCLSpec where prscl_ID in
 (
 SELECT prs_ID FROM TA_Person
 where Prs_Barcode='00000000' and Prs_Active=0 and prs_CreationDate <= dateadd(day,datediff(day,@daycount,GETDATE()),0)
 )

 DELETE FROM TA_PersonTASpec where prsta_ID in
 (
 SELECT prs_ID FROM TA_Person
 where Prs_Barcode='00000000' and Prs_Active=0 and prs_CreationDate <= dateadd(day,datediff(day,@daycount,GETDATE()),0)
 )

DELETE FROM TA_Person
 where Prs_Barcode='00000000' and Prs_Active=0 and prs_CreationDate <= dateadd(day,datediff(day,@daycount,GETDATE()),0)

 DELETE FROM CL_Contractor
 where contractor_Name='00000000'  and contractor_CreationDate <= dateadd(day,datediff(day,@daycount,GETDATE()),0)
";
            base.RunSQL(SQLCommand);
        }

        /// <summary>
        /// آی-کوئری پرسنل یکه شاخه از چارت سازمانی را بر اساس نوع اضافه کار تشویقی بر می گرداند
        /// </summary>
        /// <param name="departmenParentID">کلید شاخه چارت سازمانی</param>
        /// <param name="overTimePersuasiveType">نوع اضافه کار تشویقی</param>
        /// <returns>آی-کوئری پرسنل</returns>
        public IQueryOver<Person, Person> GetPersonsByDepartmentParentID(decimal departmenParentID, OverTimePersuasiveType overTimePersuasiveType)
        {
            Department departmentAlias = null;
            Person personAlias = null;
            PersonTASpec personTASpecAlias = null;

            switch (overTimePersuasiveType)
            {
                case OverTimePersuasiveType.OverTimeWork:
                    return NHibernateSession.QueryOver(() => personAlias)
                                        .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                        .JoinAlias(() => personAlias.PersonTASpecList, () => personTASpecAlias)
                                        .Where(() =>
                                                    personAlias.IsDeleted != true &&
                                                    personAlias.Active == true &&
                                                   (departmentAlias.ParentPath.IsLike("," + departmenParentID.ToString() + ",", MatchMode.Anywhere) || departmentAlias.ID == departmenParentID) &&
                                                    personTASpecAlias.HasPeyment == true);

                case OverTimePersuasiveType.HolidayWork:
                    return NHibernateSession.QueryOver(() => personAlias)
                                       .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                       .JoinAlias(() => personAlias.PersonTASpecList, () => personTASpecAlias)
                                       .Where(() =>
                                                   personAlias.IsDeleted != true &&
                                                   personAlias.Active == true &&
                                                 (departmentAlias.ParentPath.IsLike("," + departmenParentID.ToString() + ",", MatchMode.Anywhere) || departmentAlias.ID == departmenParentID) &&
                                                   personTASpecAlias.HolidayWork == true);

                case OverTimePersuasiveType.NightWork:
                    return NHibernateSession.QueryOver(() => personAlias)
                                       .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                       .JoinAlias(() => personAlias.PersonTASpecList, () => personTASpecAlias)
                                       .Where(() =>
                                                   personAlias.IsDeleted != true &&
                                                   personAlias.Active == true &&
                                                  (departmentAlias.ParentPath.IsLike("," + departmenParentID.ToString() + ",", MatchMode.Anywhere) || departmentAlias.ID == departmenParentID) &&
                                                   personTASpecAlias.NightWork == true);

            }

            return null;
        }

        /// <summary>
        /// آی-کوئری پرسنل برای استفاده در اضافه کار تشویقی بر می گرداند
        /// </summary>
        /// <returns>آی-کوئری پرسنل</returns>
        public IQueryOver<Person, Person> GetPersonsInfoForOverTime()
        {
            Department departmentAlias = null;
            Person personAlias = null;
            PersonTASpec personTASpecAlias = null;

            return NHibernateSession.QueryOver(() => personAlias)
                                     .JoinAlias(() => personAlias.ExtDepartment, () => departmentAlias)
                                     .JoinAlias(() => personAlias.PersonTASpecList, () => personTASpecAlias)
                                     .Where(() =>
                                                 personAlias.IsDeleted != true &&
                                                 personAlias.Active == true);
        }

    }

}




