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
    
    public partial class TicketCerradoGet_Result
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Nullable<int> AsientoId { get; set; }
        public string Asiento { get; set; }
        public Nullable<int> ParadaOrigenId { get; set; }
        public string Origen { get; set; }
        public Nullable<int> ParadaDestinoId { get; set; }
        public string Destino { get; set; }
        public Nullable<int> ServicioEfectivoId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string Cliente { get; set; }
        public Nullable<int> LineaId { get; set; }
        public string Linea { get; set; }
        public int VentaId { get; set; }
        public string Hora { get; set; }
        public decimal Tarifa { get; set; }
        public string Observaciones { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public Nullable<decimal> ConTarjeta { get; set; }
        public Nullable<int> Exceso { get; set; }
        public System.DateTime FVenta { get; set; }
        public Nullable<int> Minutos { get; set; }
        public string UserMarca { get; set; }
        public Nullable<System.DateTime> FechaMarca { get; set; }
    }
}