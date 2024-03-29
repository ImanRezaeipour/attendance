using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Infrastructure.Utility;

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

    public class UnderManagementPerson
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID value.
        /// </summary>
        public virtual Decimal ID { get; set; }

        /// <summary>
        /// Gets or sets the Date value.
        /// </summary>
        public virtual String BarCode { get; set; }

        public virtual String CardNum { get; set; }

        public virtual String PersonName { get; set; }
         
        public virtual string Family { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual decimal PersonId { get; set; }

        public virtual int DateRangeOrder { get; set; }

        public virtual int DateRangeOrderIndex { get; set; }

        public virtual String DepartmentName { get; set; }
        
        public virtual String ShiftName { get; set; }
        
        public virtual String RemainLeaveToMonthEnd { get; set; }

        public virtual String RemainLeaveToYearEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FirstEntrance value.
        /// </summary>
        public virtual String FirstEntrance
        {
            /*   get
               {
                   if (this.CurrentProceedTrafficList.Count >= 1)
                       return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[0].From);
                   else
                       return "";
               }*/
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the FirstExit value.
        /// </summary>
        public virtual String FirstExit
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 1)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[0].To);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the SecondEntrance value.
        /// </summary>
        public virtual String SecondEntrance
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 2)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[1].From);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the SecondExit value.
        /// </summary>
        public virtual String SecondExit
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 2)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[1].To);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ThirdEntrance value.
        /// </summary>
        public virtual String ThirdEntrance
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 3)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[2].From);
                else
                    return "";
            }*/
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the ThirdExit value.
        /// </summary>
        public virtual String ThirdExit
        {
           /* get
            {
                if (this.CurrentProceedTrafficList.Count >= 3)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[2].To);
                else
                    return "";
            }*/
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the FourthEntrance value.
        /// </summary>
        public virtual String FourthEntrance
        {
           /* get
            {
                if (this.CurrentProceedTrafficList.Count >= 4)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[3].From);
                else
                    return "";
            }*/
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the FourthExit value.
        /// </summary>
        public virtual String FourthExit
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 4)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[3].To);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FifthEntrance value.
        /// </summary>
        public virtual String FifthEntrance
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 5)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[4].From);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FifthExit value.
        /// </summary>
        public virtual String FifthExit
        {
            /*get
            {
                if (this.CurrentProceedTrafficList.Count >= 5)
                    return Utility.IntTimeToRealTimeWithZero(this.CurrentProceedTrafficList[4].To);
                else
                    return "";
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LastExit value.
        /// </summary>
        public virtual String LastExit
        {
            /*get
            {
                CurrentProceedTraffic currentProceedTraffic = this.CurrentProceedTrafficList.LastOrDefault();
                if (currentProceedTraffic == null)
                    return "";
                else
                    return Utility.IntTimeToRealTimeWithZero(currentProceedTraffic.From);
            }*/
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the NecessaryOperation value.
        /// </summary>
        public virtual String NecessaryOperation
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_NecessaryOperation", out PeriodicScndCnpValue);
            //    return Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //}
            get;
            set;
        } 

        /// <summary>
        /// Gets or sets the HourlyPureOperation value.
        /// </summary>
        public virtual String HourlyPureOperation
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyPureOperation", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyPureOperation value.
        /// </summary>
        public virtual String DailyPureOperation
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyPureOperation", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ImpureOperation value.
        /// </summary>
        public virtual String ImpureOperation
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ImpureOperation", out PeriodicScndCnpValue);
            //    return Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the AllowableOverTime value.
        /// </summary>
        public virtual String AllowableOverTime
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_AllowableOverTime", out PeriodicScndCnpValue);
            //    return Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UnallowableOverTime value.
        /// </summary>
        public virtual String UnallowableOverTime
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_UnallowableOverTime", out PeriodicScndCnpValue);
            //    return Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyAllowableAbsence value.
        /// </summary>
        public virtual String HourlyAllowableAbsence
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyAllowableAbsence", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyUnallowableAbsence value.
        /// </summary>
        public virtual String HourlyUnallowableAbsence
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;s
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyUnallowableAbsence", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyAbsence value.
        /// </summary>
        public virtual String DailyAbsence
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyAbsence", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyMission value.
        /// </summary>
        public virtual String HourlyMission
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyMission", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyMission value.
        /// </summary>
        public virtual String DailyMission
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyMission", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HostelryMission value.
        /// </summary>
        public virtual String HostelryMission
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HostelryMission", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlySickLeave value.
        /// </summary>
        public virtual String HourlySickLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlySickLeave", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailySickLeave value.
        /// </summary>
        public virtual String DailySickLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailySickLeave", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyMeritoriouslyLeave value.
        /// </summary>
        public virtual String HourlyMeritoriouslyLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyMeritoriouslyLeave", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyMeritoriouslyLeave value.
        /// </summary>
        public virtual String DailyMeritoriouslyLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyMeritoriouslyLeave", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyWithoutPayLeave value.
        /// </summary>
        public virtual String HourlyWithoutPayLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyWithoutPayLeave", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the PresenceDuration value.
        /// </summary>
        public virtual String PresenceDuration
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_PresenceDuration", out PeriodicScndCnpValue);
            //    return Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyWithoutPayLeave value.
        /// </summary>
        public virtual String DailyWithoutPayLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyWithoutPayLeave", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HourlyWithPayLeave value.
        /// </summary>
        public virtual String HourlyWithPayLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_HourlyWithPayLeave", out PeriodicScndCnpValue);
            //    string value = Utility.IntTimeToTime(PeriodicScndCnpValue == null ? 0 : PeriodicScndCnpValue.PeriodicValue);
            //    return value;
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DailyWithPayLeave value.
        /// </summary>
        public virtual String DailyWithPayLeave
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_DailyWithPayLeave", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField1 value.
        /// </summary>
        public virtual String ReserveField1
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField1", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField2 value.
        /// </summary>
        public virtual String ReserveField2
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField2", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField3 value.
        /// </summary>
        public virtual String ReserveField3
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField3", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField4 value.
        /// </summary>
        public virtual String ReserveField4
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField4", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField5 value.
        /// </summary>
        public virtual String ReserveField5
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField5", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField6 value.
        /// </summary>
        public virtual String ReserveField6
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField6", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField7 value.
        /// </summary>
        public virtual String ReserveField7
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField7", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField8 value.
        /// </summary>
        public virtual String ReserveField8
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField8", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField9 value.
        /// </summary>
        public virtual String ReserveField9
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField9", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ReserveField10 value.
        /// </summary>
        public virtual String ReserveField10
        {
            //get
            //{
            //    ScndCnpValue PeriodicScndCnpValue = null;
            //    this.PeriodicScndCnpValueList.TryGetValue("gridFields_ReserveField10", out PeriodicScndCnpValue);
            //    return PeriodicScndCnpValue == null ? "0" : PeriodicScndCnpValue.PeriodicValue.ToString();
            //}
            get;
            set;
        }

        public virtual IList<CurrentProceedTraffic> CurrentProceedTrafficList
        {
            get;
            set;
        }

        public virtual IDictionary<string, ScndCnpValue> PeriodicScndCnpValueList
        {
            get;
            set;
        }

        ///// <summary>
        ///// Gets or sets the Shift value.
        ///// </summary>
        //public virtual Shift Shift { get; set; }

        //public virtual GridColumnColor TrafficColor { get; set; }

        //public virtual GridColumnColor HourlyabsenceColor { get; set; }

        //public virtual GridColumnColor DailyabsenceColor { get; set; }


        #endregion
    }
}