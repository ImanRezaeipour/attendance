using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using GTS.Clock.Model;
using GTS.Clock.Model.Charts;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Model.BaseInformation;
using GTS.Clock.Infrastructure.NHibernateFramework;
namespace GTS.Clock.Infrastructure.Repository
{
    public class DutyPlaceRepository : RepositoryBase<DutyPlace>
    {
        private ISession NHSession = NHibernateSessionManager.Instance.GetSession();
        public override string TableName
        {
            get { return "TA_DutyPlace"; }
        }

        public DutyPlaceRepository(bool Disconnectedly)
            : base(Disconnectedly)
        { }

        public IList<DutyPlace> GetDutyPlaceTree()
        {
            ICriteria crit = this.NHibernateSession.CreateCriteria(typeof(DutyPlace));
            crit.Add(Expression.Or(
                Expression.IsNull("ParentID"),
                Expression.Eq("ParentID", Convert.ToDecimal(0))));

            IList<DutyPlace> parents = crit.List<DutyPlace>();            

            return parents;
        }

        public DutyPlace GetRoot() 
        {
            IList<DutyPlace> list = this.GetDutyPlaceTree();
            return list.FirstOrDefault();
        }
        public decimal GetParentID(decimal dutyPlaceID)
        {
            DutyPlace dutyPlace = NHSession.QueryOver<DutyPlace>()
                                                      .Where(x => x.ID == dutyPlaceID)
                                                      .SingleOrDefault();
            NHibernateSessionManager.Instance.GetSession().Evict(dutyPlace);
            if (dutyPlace != null && dutyPlace.ParentID != null)
                return dutyPlace.ParentID;
            return 0;
        }
        public bool IsRoot(decimal dutyPlaceID)
        {
            if (GetParentID(dutyPlaceID) == 0)
                return true;
            return false;
        }
        
        
    }
}
