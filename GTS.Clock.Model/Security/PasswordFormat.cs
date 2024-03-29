using System;
using System.Collections.Generic;
using System.Linq;
using GTS.Clock.Model.Concepts;
using GTS.Clock.Model.Charts;
using GTS.Clock.Model;
using GTS.Clock.Infrastructure.RepositoryFramework;
using GTS.Clock.Infrastructure.Utility;
using GTS.Clock.Infrastructure.Exceptions;
using System.Web.Security;

namespace GTS.Clock.Model.Security
{
    public class PasswordFormat : IEntity
    {
        public PasswordFormat()
        {
        }

        #region Properties

        public virtual decimal ID
        {
            get;
            set;
        }

        public virtual bool ContainsWords
        {
            get;
            set;
        }

        public virtual bool ContainsNumbers
        {
            get;
            set;
        }



        public virtual bool ContainsSymbols
        {
            get;
            set;
        }

        public virtual int MinLength
        {
            get;
            set;
        }

        public virtual int MaxLength
        {
            get;
            set;
        }


        #endregion    


    }
}
