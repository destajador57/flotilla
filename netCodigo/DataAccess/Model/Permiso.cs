//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Permiso
    {
        public decimal idPermiso { get; set; }
        public Nullable<decimal> idRol { get; set; }
        public Nullable<decimal> idFase { get; set; }
        public Nullable<decimal> idCatalogo { get; set; }
        public Nullable<short> permiso1 { get; set; }
    
        public virtual Fase Fase { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
