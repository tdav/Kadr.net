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

    public partial class TBQARINDOSH : XPLiteObject
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
        [Association(@"TBQARINDOSHReferencesTBMAIN")]
        public TBMAIN MAINID
        {
            get { return fMAINID; }
            set { SetPropertyValue<TBMAIN>("MAINID", ref fMAINID, value); }
        }
        string fLASTNAME;
        [Size(50)]
        public string LASTNAME
        {
            get { return fLASTNAME; }
            set { SetPropertyValue<string>("LASTNAME", ref fLASTNAME, value); }
        }
        string fFIRSTNAME;
        [Size(50)]
        public string FIRSTNAME
        {
            get { return fFIRSTNAME; }
            set { SetPropertyValue<string>("FIRSTNAME", ref fFIRSTNAME, value); }
        }
        string fPATRONYMIC;
        [Size(50)]
        public string PATRONYMIC
        {
            get { return fPATRONYMIC; }
            set { SetPropertyValue<string>("PATRONYMIC", ref fPATRONYMIC, value); }
        }
        int fQARINDOSHLIGI;
        public int QARINDOSHLIGI
        {
            get { return fQARINDOSHLIGI; }
            set { SetPropertyValue<int>("QARINDOSHLIGI", ref fQARINDOSHLIGI, value); }
        }
        string fDATAROJ;
        [Size(4)]
        public string DATAROJ
        {
            get { return fDATAROJ; }
            set { SetPropertyValue<string>("DATAROJ", ref fDATAROJ, value); }
        }
        string fBIRTHCOUNTRY;
        [Size(300)]
        public string BIRTHCOUNTRY
        {
            get { return fBIRTHCOUNTRY; }
            set { SetPropertyValue<string>("BIRTHCOUNTRY", ref fBIRTHCOUNTRY, value); }
        }
        int fCOUNTRY;
        public int COUNTRY
        {
            get { return fCOUNTRY; }
            set { SetPropertyValue<int>("COUNTRY", ref fCOUNTRY, value); }
        }
        int fREGION;
        public int REGION
        {
            get { return fREGION; }
            set { SetPropertyValue<int>("REGION", ref fREGION, value); }
        }
        int fRAYON;
        public int RAYON
        {
            get { return fRAYON; }
            set { SetPropertyValue<int>("RAYON", ref fRAYON, value); }
        }
        string fYASHASHJOYI;
        [Size(400)]
        public string YASHASHJOYI
        {
            get { return fYASHASHJOYI; }
            set { SetPropertyValue<string>("YASHASHJOYI", ref fYASHASHJOYI, value); }
        }
        string fISHJOYI;
        [Size(400)]
        public string ISHJOYI
        {
            get { return fISHJOYI; }
            set { SetPropertyValue<string>("ISHJOYI", ref fISHJOYI, value); }
        }
        string fDEATH;
        [Size(4)]
        public string DEATH
        {
            get { return fDEATH; }
            set { SetPropertyValue<string>("DEATH", ref fDEATH, value); }
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