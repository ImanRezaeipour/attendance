using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model.Charts;
using GTS.Clock.Model.MonthlyReport;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Model.Security;

namespace GTS.Clock.Model.RequestFlow
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

    public class Manager : IEntity
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public virtual Decimal ID { get; set; }

        public virtual bool Active { get; set; }

		/// <summary>
		/// Gets or sets the Person value.
		/// </summary>
		public virtual Person Person { get; set; }

        /// <summary>
        /// جهت کاربری راحتر در واسط کاربر
        /// </summary>
        public virtual Person ThePerson
        {
            get
            {
                if (Person != null)
                    return this.Person;
                if (OrganizationUnit != null && OrganizationUnit.Person != null)
                    return OrganizationUnit.Person;
                return new Person();
            }
        }

        /// <summary>
        /// جهت کاربری راحتر در واسط کاربر
        /// </summary>
        public virtual OrganizationUnit TheOrganizationUnit
        {
            get
            {
                if (OrganizationUnit != null)
                    return this.OrganizationUnit;
                if (Person != null && Person.OrganizationUnit != null)
                    return Person.OrganizationUnit;
                return new OrganizationUnit();
            }
        }

		/// <summary>
		/// Gets or sets the Unit value.
		/// </summary>
        public virtual OrganizationUnit OrganizationUnit { get; set; }

        public virtual IList<ManagerFlow> ManagerFlowList { get; set; }

        public virtual ManagerAssignType ManagerType {
            get 
            {
                if (OrganizationUnit != null && Person != null)
                   return ManagerAssignType.OrganizationUnit;
                if (Person == null)
                    return ManagerAssignType.OrganizationUnit;
                if (OrganizationUnit == null) return ManagerAssignType.Person;
                return ManagerAssignType.None;
            }
        }

        public virtual IList<UnderManagementPerson> UnderManagementPersonList
        { get; set; }

        public virtual IList<UnderManagementPerson> UnderManagementOperatorPersonList
        { get; set; }

        public virtual IList<Substitute> SubstituteList { get; set; }

        public virtual IList<DAManager> DataAccessList { get; set; }
		public virtual IList<GTS.Clock.Model.Temp.Temp> TempList { get; set; } 
		#endregion		

        #region Static Methods

        public static IManagerRepository GetManagerRepository(bool Disconnectedly)
        {
            return RepositoryFactory.GetRepository<IManagerRepository, Manager>(Disconnectedly);
        }

        #endregion
    }

    public class ManagerComparer : IEqualityComparer<Manager>
    {
        public bool Equals(Manager x, Manager y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Manager obj)
        {
            return obj.ID.GetHashCode();
        }
    }

}