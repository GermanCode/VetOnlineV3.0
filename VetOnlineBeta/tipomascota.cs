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
    
    public partial class tipomascota
    {
        public tipomascota()
        {
            this.mascota = new HashSet<mascota>();
            this.raza = new HashSet<raza>();
        }
    
        public int idTipoMascota { get; set; }
        public string descTipoMasc { get; set; }
    
        public virtual ICollection<mascota> mascota { get; set; }
        public virtual ICollection<raza> raza { get; set; }
    }
}