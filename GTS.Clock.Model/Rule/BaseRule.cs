using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTS.Clock.Model
{
    /// <summary>
    /// کلاس والد براي 
    /// Rule , AssignedRule
    /// 
    /// </summary>
    public class BaseRule<TRuleParameter> : IEntity
        where TRuleParameter: BaseRuleParameter
    {

        #region properties

        public virtual decimal ID
        {
            get;
            set;
        }

        public virtual string Script
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual bool IsForcible
        {
            get;
            set;
        }

        public virtual decimal IdentifierCode
        {
            get;
            set;
        }

        public virtual IList<TRuleParameter> RuleParameterList
        {
            get;
            set;
        }

        /// <summary>
        /// مقدار پارامتری که نام آن ارسال شده است را برمی گرداند
        /// </summary>
        /// <param name="ParameterName">نام پارامتر</param>
        /// <returns>مقدار پارامتر درخواست شده</returns>
        public virtual BaseRuleParameter this[string ParameterName]
        {
            get
            {
                TRuleParameter tmp = this.RuleParameterList.Where(x => x.Name.ToUpper() == ParameterName.ToUpper())
                                             .FirstOrDefault();
                if (tmp == null)
                    throw new ArgumentException("پارامتری با نام ارسال شده یافت نشد");
                return tmp;
            }
        }



        public virtual bool IsPeriodic
        {
            get;
            set;
        }

        public virtual int Order
        {
            get;
            set;
        }

        public virtual decimal TypeId
        {
            get;
            set;
        }

        #endregion
    }
}
