using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTS.Clock.Model.Security
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
	/// 		<description>2012-02-16</description>
	/// 		<description>Created</description>
	/// 	</item>

	#endregion

	public class DARuleGroup
	{
		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public virtual Decimal ID { get; set; }

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public virtual Decimal UserID { get; set; }

		/// <summary>
		/// Gets or sets the RuleGrpID value.
		/// </summary>
		public virtual Decimal? RuleGrpID { get; set; }

		/// <summary>
		/// Gets or sets the All value.
		/// </summary>
		public virtual Boolean All { get; set; }
		public virtual User User { get; set; }

        public virtual RuleCategory RuleCategory { get; set; } 
		#endregion		
	}
}