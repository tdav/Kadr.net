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

    public partial class SA_ATESTACIYA_RES : XPLiteObject
    {
        int fID;
        [Key]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>("ID", ref fID, value); }
        }
        string fNAMEUZ;
        [Size(50)]
        public string NAMEUZ
        {
            get { return fNAMEUZ; }
            set { SetPropertyValue<string>("NAMEUZ", ref fNAMEUZ, value); }
        }
        string fNAMERU;
        [Size(50)]
        public string NAMERU
        {
            get { return fNAMERU; }
            set { SetPropertyValue<string>("NAMERU", ref fNAMERU, value); }
        }
        int fSTATE;
        public int STATE
        {
            get { return fSTATE; }
            set { SetPropertyValue<int>("STATE", ref fSTATE, value); }
        }
    }

}
