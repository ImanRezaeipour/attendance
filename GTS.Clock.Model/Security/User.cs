using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Model.Charts;
using GTS.Clock.Model;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Infrastructure.Exceptions;
using GTS.Clock.Model.AppSetting;

namespace GTS.Clock.Model.Security
{
    public class User : System.Web.Security.MembershipUser, IEntity
    {

        #region Properties

        public virtual decimal ID
        {
            get;
            set;
        }

        public virtual string UserName
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            set;
        }

        public string ConfirmPassword { get; set; }

        public string OriginalPassword { get; set; }

        /// <summary>
        /// جهت اطلاعات ورودی از واسط کاربر
        /// </summary>
        public bool IsPasswodChanged { get; set; }

        public virtual bool Active
        {
            get;
            set;
        }

        public virtual Person Person
        {
            get;
            set;
        }

        public virtual Role Role
        {
            get;
            set;
        }

        public virtual Domains Domain { get; set; }

        public virtual DateTime LastActivityDate
        {
            get;
            set;
        }

        public virtual bool ActiveDirectoryAuthenticate
        {
            get;
            set;
        }

        public virtual IList<AppSetting.UserSettings> UserSettingList
        {
            get;
            set;
        }

        public virtual bool IsAutomaticGenerated { get; set; }

        public virtual UserSettings UserSetting
        {
            get 
            {
                if (this.UserSettingList != null && this.UserSettingList.Count > 0) 
                {
                    return this.UserSettingList[0];
                }
                return new UserSettings();
            }
            set 
            {
                if (this.UserSettingList == null )
                {
                    this.UserSettingList = new List<UserSettings>();
                }
                if (this.UserSettingList.Count == 0)
                {
                    this.UserSettingList.Add(value);
                }
                else
                {
                    this.UserSettingList[0] = value;
                }
            }
        }

        public virtual IList<DADepartment> DADepartmentList { get; set; }
        public virtual IList<DAOrganizationUnit> DAOrganizationUnitList { get; set; }
        public virtual IList<DAShift> DAShiftList { get; set; }
        public virtual IList<DAWorkGroup> DAWorkGroupList { get; set; }
        public virtual IList<DAPrecard> DAPrecardList { get; set; }
        public virtual IList<DACtrlStation> DACtrlStationList { get; set; }
        public virtual IList<DADoctor> DADoctorList { get; set; }
        public virtual IList<DAManager> DAManagerList { get; set; }
        public virtual IList<DARuleGroup> DARuleGroupList { get; set; }
        public virtual IList<DAFlow> DAFlowList { get; set; }
        public virtual IList<DAReport> DAReportList { get; set; }
        public virtual IList<DACorporation> DACorporationList { get; set; }
		public virtual IList<GTS.Clock.Model.Temp.Temp> TempList { get; set; } 
        #endregion

        #region Method

        public virtual bool IsOnline 
        {
            get { return base.IsOnline; }
        }

        public virtual User CreateUser(decimal personId, decimal roleId, string username, string password, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }


        public static MembershipUser ToMemershipUser(User user)
        {
            MembershipUser memUser = new MembershipUser("GTSMembershipProvider", user.Person.Name, "", "", "", "", false, true, DateTime.Now, DateTime.Now, user.LastActivityDate, DateTime.Now, DateTime.Now);
            return memUser;
        }

        public override string ToString()
        {
            string summery = "";
            summery = String.Format("شخص:{0} با نام کاربری:{1} و نقش {2} میباشد ", this.Person.Name, this.UserName, this.Role.Name);
            return summery;
        }
        #endregion
    }
}