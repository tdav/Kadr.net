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
    
    public partial class TBUNIVER
    {
        public int ID { get; set; }
        public string MAINID { get; set; }
        public string GOD_VIPUSKA { get; set; }
        public Nullable<int> OBRAZOVATELNIY_UCHERJ { get; set; }
        public string SPECIALNOST_PODIPLOMU { get; set; }
        public Nullable<int> VID_OBUCHENIYA { get; set; }
        public Nullable<int> PROFESIANAL_OBRAZ { get; set; }
        public Nullable<int> OB_TYPE { get; set; }
        public string SERIYA { get; set; }
        public Nullable<int> NUM { get; set; }
        public Nullable<System.DateTime> EDITDATE { get; set; }
        public Nullable<int> EDITUSER { get; set; }
    
        public virtual TBMAIN TBMAIN { get; set; }
    }
}
