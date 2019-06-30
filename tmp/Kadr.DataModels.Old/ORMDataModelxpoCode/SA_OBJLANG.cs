using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Asbt.Data.Xpo
{

    public partial class SA_OBJLANG
    {
        public SA_OBJLANG(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
