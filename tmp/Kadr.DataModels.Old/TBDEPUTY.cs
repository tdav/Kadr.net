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
    
    public partial class TBDEPUTY
    {
        public int ID { get; set; }
        public string MAINID { get; set; }
        public string DEPUTY { get; set; }
        public string DATE1 { get; set; }
        public string DATE2 { get; set; }
        public Nullable<System.DateTime> EDITDATE { get; set; }
        public Nullable<int> EDITUSER { get; set; }
    
        public virtual TBMAIN TBMAIN { get; set; }
    }
}
