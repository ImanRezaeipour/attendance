using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTS.Clock.Infrastructure.RepositoryFramework;

namespace GTS.Clock.Model.Security
{
    public interface IAuthorizeRepository : IRepository<Authorize>
    {
        /// <summary>
        /// لیستی از منابعی که استفاده از آن برای یک نقش خاص ممنوع است را برمیگرداند
        /// </summary>    
        /// <returns></returns>
        IList<Resource> GetAccessDenied(decimal roleID);

        /// <summary>
        /// لیستی از منابعی که استفاده از آن برای یک نقش خاص ممنوع است را برمیگرداند
        /// </summary>        
        /// <returns></returns>
        IList<Resource> GetAccessDenied(Role role);
    }
}
