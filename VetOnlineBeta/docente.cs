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
    
    public partial class docente
    {
        public docente()
        {
            this.estudiante = new HashSet<estudiante>();
            this.servicio = new HashSet<servicio>();
        }
    
        public int idDocente { get; set; }
        public System.DateTime fecha_creacion_d { get; set; }
        public long Telefono { get; set; }
    
        public virtual persona persona { get; set; }
        public virtual ICollection<estudiante> estudiante { get; set; }
        public virtual ICollection<servicio> servicio { get; set; }
    }
}
