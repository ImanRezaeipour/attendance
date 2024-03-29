using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Infrastructure;

namespace GTS.Clock.Model.Charts
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

    public class Department : IEquatable<Department>, IEntity
    {
       
        public Department() 
        {
            //this.Visible = true;
            this.Visible = false;
        }

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
        /// Gets or sets the CustomCode value.
        /// </summary>
        public virtual String CustomCode { get; set; }

        /// <summary>
        /// بمنظور ارتباط راحتر با واسط کاربر
        /// </summary>
        public virtual decimal ParentID
        {
            get
            {
                if (this.Parent == null)
                    return 0;
                return this.Parent.ID;
            }
            set
            {
                if (value > 0)
                {
                    if (this.Parent == null)
                        this.Parent = new Department();
                    this.Parent.ID = value;
                }
                else 
                    this.Parent = null;
            }
        }

        public virtual IList<GTS.Clock.Model.Temp.Temp> TempList { get; set; } 

        /// <summary>
        /// جهت استفاده در واسط کاربر و 
        /// البته فرم مربوط به گزارش کارکرد
        /// و فرم مربوط به دسترسی اطلاعات
        /// </summary>
        public virtual bool Visible { get; set; }

        public virtual string ParentPath { get; set; }

        public virtual DepartmentType DepartmentType { get; set; }

        public virtual IList<decimal> ParentPathList
        {
            get
            {
                List<decimal> list = new List<decimal>();
                string path = this.ParentPath == null ? "" : this.ParentPath;
                string[] ids = path.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in ids)
                {
                    list.Add(Utility.ToInteger(id));
                }
                return list;
            }
        }

        /// <summary>
        /// Gets or sets the ParentID value.
        /// </summary>
        public virtual Department Parent { get; set; }

        public virtual IList<Department> ChildList { get; set; }

        public virtual IList<Person> PersonList { get; set; }

        public virtual IList<DepartmentPosition> PositionList { get; set; }

        #endregion

        #region IEquatable<Department> Members

        public virtual bool Equals(Department other)
        {
            if (this.ID == other.ID)
                return true;
            return false;
        }

        #endregion
    }
}