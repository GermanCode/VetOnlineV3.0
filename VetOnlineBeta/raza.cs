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
    
    public partial class raza
    {
        public raza()
        {
            this.mascota = new HashSet<mascota>();
        }
    
        public int idRaza { get; set; }
        public int fkTipoMasc { get; set; }
        public string DescRaza { get; set; }
    
        public virtual ICollection<mascota> mascota { get; set; }
        public virtual tipomascota tipomascota { get; set; }
    }
}