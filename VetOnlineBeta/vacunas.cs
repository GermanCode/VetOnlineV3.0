//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VetOnlineBeta
{
    using System;
    using System.Collections.Generic;
    
    public partial class vacunas
    {
        public vacunas()
        {
            this.vacunas_mascota = new HashSet<vacunas_mascota>();
        }
    
        public int idVacuna { get; set; }
        public int fkTipoEnfermedad { get; set; }
        public string descVacuna { get; set; }
    
        public virtual ICollection<vacunas_mascota> vacunas_mascota { get; set; }
    }
}
