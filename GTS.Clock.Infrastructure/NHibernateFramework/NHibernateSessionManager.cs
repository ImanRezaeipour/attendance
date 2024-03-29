using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using NHibernate.Context;
using System.Collections;
using GTS.Clock.Infrastructure.Exceptions;
using System.Data;


namespace GTS.Clock.Infrastructure.NHibernateFramework
{
    /// <summary>
    /// .اين کلاس مسئول ايجاد و مديرت "جلسه" ها و "تراکنش" ها مي باشد
    /// .اين کلاس به صورت "يگانه" تعريف شده است، به اين دليل که هزينه ايجاد "سازنده جلسه" بسيار بالاست
    /// </summary>
    public class NHibernateSessionManager
    {

        #region Variables

        private ISessionFactory sessionFactory;
        private Mutex mut = new Mutex();

        #endregion

        #region Consts

        private const string modelAssamblyName = "GTS.Clock.Model";
        private const string SESSION_KEY = "CONTEXT_SESSIONS";
        private const string TRANSACTION_KEY = "CONTEXT_TRANSACTIONS";
        private const string FILTERS_KEY = "NHIBERNATEFILTERS_KEY";

        #endregion

        #region Constructors

        private NHibernateSessionManager()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// .يک نمونه از کلاس "مدير جلسه" را برمي گرداند
        /// </summary>
        public static NHibernateSessionManager Instance
        {
            get
            {
                return Nested.NHibernateSessionManager;
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private static class Nested
        {
            static Nested() { }
            internal static readonly NHibernateSessionManager NHibernateSessionManager =
                new NHibernateSessionManager();
        }

        private IDictionary<string, string> sessionFactoryPropsDic = new Dictionary<string, string>();
        public IDictionary<string, string> SessionFactoryPropsDic 
        {
            get
            {
                return this.sessionFactoryPropsDic;
            }
            set
            {
                this.sessionFactoryPropsDic = value;
            }
        }

        /// <summary>
        /// .براساس تنظيمات پروژه ي فراخواننده و پروژه ي پيش فرض براي نگهداري نحوه ي نگاشت يک نمونه "سازنده ي جلسه" برميگرداند
        /// not thread-safe
        /// </summary>
        /// <returns>يک نمونه سازنده ي جلسه</returns>
        public ISessionFactory GetSessionFactory()
        {
            if (this.sessionFactory == null)
            {
                try
                {
                    Configuration config = new Configuration();
                    if(this.sessionFactoryPropsDic.Count > 0)
                       config.SetProperties(this.sessionFactoryPropsDic);
                    config.AddAssembly(modelAssamblyName);
                    this.sessionFactory = config.BuildSessionFactory();

                    /*
                    Configuration nhConfigurationCache;
                    //var nhCfgCache = new NhibernateCfgFileCache(modelAssamblyName);
                    var cachedCfg = null;// nhCfgCache.LoadConfigurationFromFile();
                    if (cachedCfg == null)
                    {
                        nhConfigurationCache = new Configuration();
                        nhConfigurationCache.AddAssembly(modelAssamblyName);
                        nhCfgCache.SaveConfigurationToFile(nhConfigurationCache);
                    }
                    else
                    {
                        nhConfigurationCache = cachedCfg;
                    }

                    this.sessionFactory = nhConfigurationCache.BuildSessionFactory();*/
                }
                catch (Exception ex)
                {
                    throw new NHibernateException("خطا در ایجاد تولید کننده جلسه", ExceptionType.FATAL, "GTS.Clock.Infrastructure.NHibernateFramework.NHibernateSessionManager.GetSessionFactory()", ex);
                }
            }
            return this.sessionFactory;
        }

        /// <summary>
        /// .براساس تنظيمات پروژه ي فراخواننده و پروژه ي پيش فرض براي نگهداري نحوه ي نگاشت يک نمونه "سازنده ي جلسه" برميگرداند
        /// not thread-safe
        /// </summary>
        /// <returns>يک نمونه سازنده ي جلسه</returns>
        public NhibernateFilters GetFilters()
        {
            if (this.ContextFilters == null)
            {
                this.ContextFilters = new NhibernateFilters();
            }
            return this.ContextFilters;
        }

        /// <summary>
        /// .يک "جلسه" برمي گرداند. اين نمونه براي تمام زمان زندگي درخواست يکسان خواهد بود
        /// so it's not thread-safe
        /// </summary>
        public ISession GetSession()
        {
            ISession session = (ISession)this.ContextSession;
            if (session == null)
            {
                try
                {
                    mut.WaitOne();
                    session = GetSessionFactory().OpenSession();
                }
                finally
                {
                    mut.ReleaseMutex();
                }
                //session.FlushMode = FlushMode.Never;
                this.ContextSession = session;
            }

            return session;
        }

        /// <summary>
        /// تراکنش جاری را برمی گرداند
        /// </summary>
        public ITransaction GetTransaction()
        {
            return (ITransaction)ContextTransaction;
        }

        /// <summary>
        /// .يک "تراکنش" برمي گرداند. اين نمونه براي تمام زمان زندگي درخواست يکسان خواهد بود
        /// so it's not thread-safe
        /// </summary>
        public ITransaction BeginTransactionOn(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            ITransaction transaction = (ITransaction)ContextTransaction;
            IDisposable ds = (IDisposable)transaction;
            if (transaction == null || transaction.IsAlreadyDisposed)
            {
                transaction = this.GetSession().BeginTransaction(isolationLevel);
                ContextTransaction = transaction;
            }
            return transaction;
        }

        /// <summary>
        /// .يک "تراکنش" برمي گرداند. اين نمونه براي تمام زمان زندگي درخواست يکسان خواهد بود
        /// so it's not thread-safe
        /// </summary>
        public ITransaction BeginTransactionOn(FlushMode flushMode, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            ITransaction transaction = (ITransaction)ContextTransaction;
            IDisposable ds = (IDisposable)transaction;
            if (transaction == null || transaction.IsAlreadyDisposed)
            {
                this.GetSession().FlushMode = flushMode;
                transaction = this.GetSession().BeginTransaction(isolationLevel);
                ContextTransaction = transaction;
            }
            return transaction;
        }

        /// <summary>
        /// تاييد تراکنش جاري
        /// <returns>مشخص کننده ی موفقیت/عدم موفقیت آمیز بودن تایید تراکنش</returns>
        /// </summary>
        public bool CommitTransactionOn()
        {
            ITransaction transaction = (ITransaction)ContextTransaction;
            if (transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack)
            {
                transaction.Commit();
                ContextTransaction = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// عقب گرد تراکنش جاري
        /// </summary>
        public void RollbackTransactionOn()
        {
            ITransaction transaction = (ITransaction)ContextTransaction;
            try
            {
                if (transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack && transaction.GetDbTransaction.Connection != null)
                {
                    transaction.Rollback();
                    ContextTransaction = null;
                }
            }
            catch(Exception ex)
            {
                string className =Utility.Utility.CallerCalassName;
                string methodName = Utility.Utility.CallerMethodName;
                string path = String.Format("class:{0},method:{1} ", className, methodName);
                throw new NHibernateException(path + "خطا در عقب گرد تراکنش جاری", ExceptionType.FATAL, "NHibernateSessionManager.RollbackTransactionOn()", ex);
            }
        }

        /// <summary>
        /// بستن جلسه جاري
        /// </summary>
        public void CloseSessionOn()
        {
            ISession session = (ISession)ContextSession;
            if (session != null && session.IsOpen)
            {
                //session.Flush();
                session.Close();
                ContextSession = null;
            }
        }

        /// <summary>
        /// وظیفه ی پاکسازی جلسه جاری را به عهده دارد.
        /// به واسطه ی این پاکسازی تمام اشیایی که کش شده بودند از بین خواهند رفت
        /// </summary>
        public void ClearSession()
        {
            ((ISession)this.GetSession()).Clear();
        }

        public object ContextSession
        {
            get
            {
                return CallContext.GetData(SESSION_KEY);
            }
            set
            {
                CallContext.SetData(SESSION_KEY, value);
            }
        }

        private object ContextTransaction
        {
            get
            {
                return CallContext.GetData(TRANSACTION_KEY);
            }
            set
            {
                CallContext.SetData(TRANSACTION_KEY, value);
            }
        }

        private NhibernateFilters ContextFilters
        {
            get
            {
                return (NhibernateFilters)CallContext.GetData(FILTERS_KEY);
            }
            set
            {
                CallContext.SetData(FILTERS_KEY, value);
            }
        }

        private bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }

        #endregion

    }
}
