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

    public partial class TBMESTORAB : XPLiteObject
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
        [Association(@"TBMESTORABReferencesTBMAIN")]
        public TBMAIN MAINID
        {
            get { return fMAINID; }
            set { SetPropertyValue<TBMAIN>("MAINID", ref fMAINID, value); }
        }
        string fDATE1;
        [Size(4)]
        public string DATE1
        {
            get { return fDATE1; }
            set { SetPropertyValue<string>("DATE1", ref fDATE1, value); }
        }
        string fDATE2;
        [Size(4)]
        public string DATE2
        {
            get { return fDATE2; }
            set { SetPropertyValue<string>("DATE2", ref fDATE2, value); }
        }
        string fISHJOYI;
        [Size(150)]
        public string ISHJOYI
        {
            get { return fISHJOYI; }
            set { SetPropertyValue<string>("ISHJOYI", ref fISHJOYI, value); }
        }
        int fWORKPLACE;
        public int WORKPLACE
        {
            get { return fWORKPLACE; }
            set { SetPropertyValue<int>("WORKPLACE", ref fWORKPLACE, value); }
        }
        string fLAVOZIM;
        [Size(500)]
        public string LAVOZIM
        {
            get { return fLAVOZIM; }
            set { SetPropertyValue<string>("LAVOZIM", ref fLAVOZIM, value); }
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
