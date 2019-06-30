using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Asbt.Data.Xpo
{

    public partial class SA_VID_OBUCHENIYA
    {
        public SA_VID_OBUCHENIYA(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
