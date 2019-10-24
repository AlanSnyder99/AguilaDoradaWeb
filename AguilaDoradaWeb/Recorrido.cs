//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AguilaDoradaWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recorrido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recorrido()
        {
            this.Servicio = new HashSet<Servicio>();
            this.Tarifa = new HashSet<Tarifa>();
            this.Trayecto = new HashSet<Trayecto>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string OrigenCNRT { get; set; }
        public string PciaOCNRT { get; set; }
        public string DestinoCNRT { get; set; }
        public string PciaDCNRT { get; set; }
        public string HoraP { get; set; }
        public string HoraL { get; set; }
        public Nullable<int> Dia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicio> Servicio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarifa> Tarifa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trayecto> Trayecto { get; set; }
    }
}
