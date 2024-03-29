using System;
using System.Text;
using System.Runtime.Serialization;
using GTS.Clock.Infrastructure.Exceptions;
using GTS.Clock.Infrastructure.Utility;

namespace GTS.Clock.Infrastructure.Exceptions
{
	public class TrafficMapperRuleException : BaseException
	{

        public TrafficMapperRuleException(string PersonCode, string RuleName, DateTime Date, Exception ex)
            : base(String.Format("خطا در نگاشت تردد های پرسنل {0} در تاریخ {1} ", PersonCode, Utility.Utility.ToPersianDate(Date)), String.Format("TrafficMapper->{0}", RuleName, ex))
        {

        }

        public TrafficMapperRuleException(string PersonCode, string RuleName, Exception ex)
            : base(String.Format("خطا در نگاشت تردد های پرسنل {0} ", PersonCode), String.Format("TrafficMapper->{0}", RuleName, ex))
        {

        }
			
		
			
	}
}
