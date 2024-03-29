using System;
using System.Configuration;

namespace GTS.Clock.Infrastructure.CalculatorSchedulerFramework.Configuration
{
    public class CalculatorSchedulerSettings : ConfigurationSection
    {

        [ConfigurationProperty(CalculatorSchedulerConstants.SchedulerIntervalAttributeName, 
            IsRequired = true)]
        public string Interval
        {
            get 
            {
                return (string)this[CalculatorSchedulerConstants.SchedulerIntervalAttributeName]; 
            }
            set 
            {
                this[CalculatorSchedulerConstants.SchedulerIntervalAttributeName] = value; 
            }
        }

        [ConfigurationProperty(CalculatorSchedulerConstants.SchedulerFromTimeAttributeName,
          IsRequired = true)]
        public string FromTime
        {
            get
            {
                return (string)this[CalculatorSchedulerConstants.SchedulerFromTimeAttributeName];
            }
            set
            {
                this[CalculatorSchedulerConstants.SchedulerFromTimeAttributeName] = value;
            }
        }

        [ConfigurationProperty(CalculatorSchedulerConstants.SchedulerToTimeAttributeName,
          IsRequired = true)]
        public string ToTime
        {
            get
            {
                return (string)this[CalculatorSchedulerConstants.SchedulerToTimeAttributeName];
            }
            set
            {
                this[CalculatorSchedulerConstants.SchedulerToTimeAttributeName] = value;
            }
        }

        /// <summary>
        /// تنظیم انجام شده در فایل تنظیمات که نحوه لاگ نمودن اتفاقات را مشخص می نماید
        /// مقدار "درست" به این معنی است که اتفاقات در زمان "ایستادن" سرویس لاگ شوند 
        /// </summary>
        [ConfigurationProperty(CalculatorSchedulerConstants.SchedulerBatchFlushAttributeName,
                IsRequired = true)]
        public bool BatchFlush
        {
            get
            {
                return Convert.ToBoolean(this[CalculatorSchedulerConstants.SchedulerBatchFlushAttributeName]);
            }
            set
            {
                this[CalculatorSchedulerConstants.SchedulerIntervalAttributeName] = value;
            }
        }

        /// <summary>
        /// نام زمانبندهای تعریف شده که با "|" از هم جدا شده اند را نگهداری می نماید
        /// </summary>
        [ConfigurationProperty(CalculatorSchedulerConstants.ServiceableSchedulersAttributeName)]
        public string ServiceableSchedulers
        {
            get 
            {
                return (string)this[CalculatorSchedulerConstants.ServiceableSchedulersAttributeName]; 
            }
            set 
            {
                this[CalculatorSchedulerConstants.ServiceableSchedulersAttributeName] = value; 
            }
        }

        [ConfigurationProperty(CalculatorSchedulerConstants.ConfigurationPropertyName,
                IsDefaultCollection = true)]
        public CalculatorSchedulerCollection CalculatorSchedulers
        {
            get { return (CalculatorSchedulerCollection)base[CalculatorSchedulerConstants.ConfigurationPropertyName]; }
        }

        /// <summary>
        /// آدرس وب سرویس
        /// </summary>
        [ConfigurationProperty(CalculatorSchedulerConstants.GTSWebServiceAddressAttributeName,
            IsRequired = true)]
        public string GTSWebServiceAddress
        {
            get
            {
                return (string)this[CalculatorSchedulerConstants.GTSWebServiceAddressAttributeName];
            }
            set
            {
                this[CalculatorSchedulerConstants.GTSWebServiceAddressAttributeName] = value;
            }
        }
    }
}
