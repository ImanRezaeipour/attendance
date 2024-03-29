using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public class ShiftException : IEntity
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public virtual Decimal ID { get; set; }

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public virtual DateTime Date { get; set; }

        /// <summary>
        /// جهت نمایش در وتاسط کاربر
        /// </summary>
        public virtual String TheDate { get; set; }
        
        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String ShiftName { get; set; }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String PersonName { get; set; }

        /// <summary>
        /// جهت نمایش در واسط کاربر
        /// </summary>
        public virtual String ShiftPairs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime RegistrationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal UserID { get; set; }

		/// <summary>
		/// Gets or sets the Person value.
		/// </summary>
		public virtual Person Person { get; set; }

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public virtual String Description { get; set; }

		/// <summary>
		/// Gets or sets the Shift value.
		/// </summary>
		public virtual Shift Shift { get; set; }
		#endregion		
	}
}