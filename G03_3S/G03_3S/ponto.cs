//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace G03_3S
{
    using System;
    using System.Collections.Generic;
    
    public partial class ponto
    {
        public int IdUsuarioPonto { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
