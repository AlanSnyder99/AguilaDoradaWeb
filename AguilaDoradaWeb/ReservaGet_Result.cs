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
    
    public partial class ReservaGet_Result
    {
        public int Id { get; set; }
        public int ParadaOrigenId { get; set; }
        public string Origen { get; set; }
        public int ParadaDestinoId { get; set; }
        public string Destino { get; set; }
        public string Cliente { get; set; }
        public int AsientoId { get; set; }
        public string Asiento { get; set; }
        public int ServicioEfectivoId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string UserId { get; set; }
    }
}