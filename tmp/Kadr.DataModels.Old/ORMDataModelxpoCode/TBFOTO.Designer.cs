//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Asbt.Data.Xpo
{

    public partial class TBFOTO : XPLiteObject
    {
        int fID;
        [Key]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>("ID", ref fID, value); }
        }
        TBMAIN fMAINID;
        [Size(50)]
        [Association(@"TBFOTOReferencesTBMAIN")]
        public TBMAIN MAINID
        {
            get { return fMAINID; }
            set { SetPropertyValue<TBMAIN>("MAINID", ref fMAINID, value); }
        }
        byte[] fFOTO;
        [Size(SizeAttribute.Unlimited)]
        public byte[] FOTO
        {
            get { return fFOTO; }
            set { SetPropertyValue<byte[]>("FOTO", ref fFOTO, value); }
        }
        DateTime fEDITDATE;
        public DateTime EDITDATE
        {
            get { return fEDITDATE; }
            set { SetPropertyValue<DateTime>("EDITDATE", ref fEDITDATE, value); }
        }
        int fEDITUSER;
        public int EDITUSER
        {
            get { return fEDITUSER; }
            set { SetPropertyValue<int>("EDITUSER", ref fEDITUSER, value); }
        }
        int fACTIVE;
        public int ACTIVE
        {
            get { return fACTIVE; }
            set { SetPropertyValue<int>("ACTIVE", ref fACTIVE, value); }
        }
    }

}