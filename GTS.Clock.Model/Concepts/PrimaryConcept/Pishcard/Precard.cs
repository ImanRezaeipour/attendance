using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Infrastructure;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Model.Security;
using GTS.Clock.Model.UIValidation;

namespace GTS.Clock.Model.Concepts
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
    /// 		<description>5/23/2011</description>
    /// 		<description>Created</description>
    /// 	</item>

    #endregion

    public class Precard : IEquatable<Precard>, IEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID value.
        /// </summary>
        public virtual Decimal ID { get; set; }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Gets or sets the pshcardGroup value.
        /// </summary>
        public virtual PrecardGroups PrecardGroup { get; set; }

        /// <summary>
        /// Gets or sets the Active value.
        /// </summary>
        public virtual Boolean Active { get; set; }

        public virtual Boolean IsHourly { get; set; }

        public virtual Boolean IsDaily { get; set; }

        public virtual Boolean IsPermit { get; set; }

        public virtual Boolean IsLock { get; set; }

        public virtual string Code { get; set; }
        public virtual string Order { get; set; }

        public virtual string RealName { get; set; }

        public virtual Boolean IsMonthly { get; set; }
        public virtual IList<UIValidationAllowedRulePrecard> AllowedRulePrecardList { get; set; }

        /// <summary>
        /// جهت نمایش درخت همراه با چک باکس در واسط کاربر
        /// </summary>
        public virtual bool ContainInPrecardAccessGroup
        {
            get;
            set;
        }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual bool IsEstelajy
        {
            get
            {
                if (this.PrecardGroup != null && this.PrecardGroup.LookupKey.ToLower().Equals(PrecardGroupsName.leaveestelajy.ToString().ToLower())) 
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual bool IsDastootyOverwork
        {
            get
            {
                if (this.Code!=null && this.Code.Trim().Equals(126.ToString()))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual bool IsDuty
        {
            get
            {
                if (this.PrecardGroup != null && this.PrecardGroup.LookupKey.ToLower().Equals(PrecardGroupsName.duty.ToString().ToLower()))
                {
                    return true;
                }
                return false;
            }
        }

        public virtual bool IsLeaveDutyEstelajy
        {
            get
            {
                if (this.PrecardGroup != null && (this.PrecardGroup.LookupKey.ToLower().Equals(PrecardGroupsName.duty.ToString().ToLower()) || this.PrecardGroup.LookupKey.ToLower().Equals(PrecardGroupsName.leave.ToString().ToLower()) || this.PrecardGroup.LookupKey.ToLower().Equals(PrecardGroupsName.leaveestelajy.ToString().ToLower())))

                {
                    return true ;
                }
                return false;
            }
        }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual bool IsTraffic { get; set; }

        public virtual IList<PrecardAccessGroup> AccessGroupList { get; set; }

        public virtual IList<Role> AccessRoleList
        {
            get;
            set;
        }

        public virtual IList<GTS.Clock.Model.Temp.Temp> TempList { get; set; }

        #endregion

        #region IEquatable<Precard> Members

        /// <summary>
        /// it used in BPrecardAccessGroup.InsertByProxy=>PrecardList.Remove()
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(Precard other)
        {
            if (this.ID == other.ID)
                return true;
            return false;
        }

        #endregion

        #region static Methods

        public static IRepository<Precard> GetPrecardRepository(bool Disconnectedly)
        {
            return RepositoryFactory.GetRepository<IPrecardRepository, Precard>(Disconnectedly);
        }

        #endregion
    }

    public class PrecardComparer : IEqualityComparer<Precard>
    {
        public bool Equals(Precard x, Precard y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Precard obj)
        {
            return obj.ID.GetHashCode();
        }
    }

}