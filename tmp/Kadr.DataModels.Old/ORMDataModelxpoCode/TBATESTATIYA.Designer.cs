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

    public partial class TBATESTATIYA : XPLiteObject
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
        [Association(@"TBATESTATIYAReferencesTBMAIN")]
        public TBMAIN MAINID
        {
            get { return fMAINID; }
            set { SetPropertyValue<TBMAIN>("MAINID", ref fMAINID, value); }
        }
        DateTime fDATE_AT;
        public DateTime DATE_AT
        {
            get { return fDATE_AT; }
            set { SetPropertyValue<DateTime>("DATE_AT", ref fDATE_AT, value); }
        }
        int fRESULT_AA;
        public int RESULT_AA
        {
            get { return fRESULT_AA; }
            set { SetPropertyValue<int>("RESULT_AA", ref fRESULT_AA, value); }
        }
        int fDOLJNOST_POSLE;
        public int DOLJNOST_POSLE
        {
            get { return fDOLJNOST_POSLE; }
            set { SetPropertyValue<int>("DOLJNOST_POSLE", ref fDOLJNOST_POSLE, value); }
        }
        string fPICHINA_NE_PRIVLICHENIYA;
        [Size(500)]
        public string PICHINA_NE_PRIVLICHENIYA
        {
            get { return fPICHINA_NE_PRIVLICHENIYA; }
            set { SetPropertyValue<string>("PICHINA_NE_PRIVLICHENIYA", ref fPICHINA_NE_PRIVLICHENIYA, value); }
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
    }

}
