//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorDeActividades.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEAM_PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEAM_PROJECT()
        {
            this.PROJECT = new HashSet<PROJECT>();
        }
    
        public int tpr_ncode { get; set; }
        public string tpr_name { get; set; }
        public Nullable<int> wok_code { get; set; }
        public Nullable<int> act_code { get; set; }
    
        public virtual ACTIVITY ACTIVITY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJECT> PROJECT { get; set; }
        public virtual WORKERS WORKERS { get; set; }
    }
}
