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
    
    public partial class ServicioADesdoblar_Result
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public System.DateTime Fecha { get; set; }
        public int RecorridoId { get; set; }
        public Nullable<int> ParadaDestinoId { get; set; }
        public Nullable<int> ParadaOrigenId { get; set; }
        public Nullable<int> Numero { get; set; }
        public Nullable<int> AsientoId { get; set; }
        public string Nombre { get; set; }
        public string Hora { get; set; }
        public int LineaId { get; set; }
        public string Recorrido { get; set; }
    }
}
