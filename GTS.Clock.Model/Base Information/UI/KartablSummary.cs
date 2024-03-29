using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Infrastructure;
using System.Runtime.Serialization;

namespace GTS.Clock.Model.BoxService
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
    /// 		<description>2011-11-29</description>
    /// 		<description>Created</description>
    /// 	</item>

    #endregion

    
    public class KartablSummary
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID value.
        /// </summary>
        public virtual Decimal ID { get; set; }

        public virtual String Key { get; set; }

        /// <summary>
        /// Gets or sets the FnTitle value.
        /// </summary>
        public virtual String FnTitle { get; set; }

        /// <summary>
        /// Gets or sets the EnTitle value.
        /// </summary>
        public virtual String EnTitle { get; set; }

        /// <summary>
        /// Gets or sets the Order value.
        /// </summary>
        public virtual Int32 Order { get; set; }

        /// <summary>
        /// Gets or sets the Active value.
        /// </summary>
        public virtual Boolean Active { get; set; }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String Title { get; set; }


        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String Value { get; set; }
        //public virtual DateTime LastRequestDate { get; set; }
        #endregion
    }
}