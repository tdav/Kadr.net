//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asbt.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBQARINDOSH
    {
        public int ID { get; set; }
        public string MAINID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string PATRONYMIC { get; set; }
        public Nullable<int> QARINDOSHLIGI { get; set; }
        public string DATAROJ { get; set; }
        public string BIRTHCOUNTRY { get; set; }
        public Nullable<int> COUNTRY { get; set; }
        public Nullable<int> REGION { get; set; }
        public Nullable<int> RAYON { get; set; }
        public string YASHASHJOYI { get; set; }
        public string ISHJOYI { get; set; }
        public string DEATH { get; set; }
        public Nullable<System.DateTime> EDITDATE { get; set; }
        public Nullable<int> EDITUSER { get; set; }
    
        public virtual TBMAIN TBMAIN { get; set; }
    }
}