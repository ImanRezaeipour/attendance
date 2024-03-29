using System;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using GTS.Clock.Model;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure.Utility;

namespace GTS.Clock.Infrastructure.Repository
{
    public class PersonWorkGroupRepository : RepositoryBase<PersonWorkGroup>, IPersonWorkGroupRepository
    {
        public override string TableName
        {
            get { return "PersonWorkgroup_view"; }
        }
        public PersonWorkGroupRepository()
            : base()
        { }

        public PersonWorkGroupRepository(bool Disconnectedly)
            : base(Disconnectedly)
        { }


        #region IPersonWorkGroupRepository Members

        public IList<AssignedWGDShift> GetAssignedWGDShift(decimal WorkGroupID)
        {
            string HQLCommand = String.Format("from AssignedWGDShift where AssignedWGDShift_WGId = {0} order by AssignedWGDShift_Date", WorkGroupID);
            IQuery query = base.NHibernateSession.CreateQuery(HQLCommand);
            return query.List<AssignedWGDShift>();
        }

        //public IList<AssignedWGDShift> GetAssignedWGDShiftByFilter(decimal WorkGroupID)
        //{
        //    if (this.NhibernateFilters.HasFilter("effectiveDate"))
        //    {                
        //        string HQLCommand = "select wgd from AssignedWGDShift wgd " +
        //                            "where wgd.WorkGroupDetailID = :WorkGroupID " +
        //                            "and wgd.Date >= :fromDate " +
        //                            "and wgd.Date <= :toDate order by wgd.Date";
        //        GTS.Clock.Infrastructure.NHibernateFramework.NhibernateFilter filter =
        //                this.NhibernateFilters.GetFilter("effectiveDate");
        //        IQuery query = base.NHibernateSession.CreateQuery(HQLCommand)
        //                                                .SetParameter("WorkGroupID", WorkGroupID)
        //                                                .SetParameter("fromDate", filter.GetItem("fromDate"))
        //                                                .SetParameter("toDate", filter.GetItem("toDate"))
        //                                                .SetResultTransformer(CriteriaSpecification.DistinctRootEntity);
        //        return query.List<AssignedWGDShift>();
        //    }
        //    else
        //    {
        //        string HQLCommand = "from AssignedWGDShift where AssignedWGDShift_WGId = :WorkGroupID ";
        //        IQuery query = base.NHibernateSession.CreateQuery(HQLCommand)
        //                                                .SetParameter("WorkGroupID", WorkGroupID);
        //        return query.List<AssignedWGDShift>();
        //    }
        //}



        #endregion

    }
}
