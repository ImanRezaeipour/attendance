using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Model;

namespace GTS.Clock.Model.Concepts
{
	public class ArchiveFieldMap 
	{
        public decimal ID { get; set; }

        /// <summary>
        /// سر ستون نمایش محاسبات
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// سر ستون نمایش محاسبات
        /// </summary>
        public string FnTitle { get; set; }

        /// <summary>
        /// سر ستون نمایش محاسبات
        /// </summary>
        public string EnTitle { get; set; }

        /// <summary>
        /// نام خصیصه کلاس بایند شده به گرید نمایش محاسبات
        /// </summary>
        public string PId { get; set; }

        /// <summary>
        /// وضعیت نمایش یک ستون
        /// </summary>
        public bool Visible { get; set; }

        public string ConceptKeyColumn { get; set; }

        public int ColumnSize { get; set; }

        public int FnColumnSize { get; set; }

        public int EnColumnSize { get; set; }

	}
}