using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Asbt.Data.Xpo
{

    public partial class TBSHAT
    {
        public TBSHAT(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}