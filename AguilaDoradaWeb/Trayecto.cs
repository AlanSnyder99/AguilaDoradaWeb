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
    
    public partial class Trayecto
    {
        public int RecorridoId { get; set; }
        public int ParadaId { get; set; }
        public byte Orden { get; set; }
        public string Duracion { get; set; }
        public Nullable<decimal> Tarifa { get; set; }
    
        public virtual Parada Parada { get; set; }
        public virtual Recorrido Recorrido { get; set; }
    }
}