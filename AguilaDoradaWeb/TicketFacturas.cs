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
    
    public partial class TicketFacturas
    {
        public int Id { get; set; }
        public double Numero { get; set; }
        public Nullable<int> AsientoId { get; set; }
        public Nullable<int> ParadaDestinoId { get; set; }
        public Nullable<int> ParadaOrigenId { get; set; }
        public Nullable<int> ServicioEfectivoId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Anulado { get; set; }
        public string ClienteId { get; set; }
        public Nullable<int> LineaId { get; set; }
        public int VentaId { get; set; }
        public string Hora { get; set; }
        public decimal Tarifa { get; set; }
        public string Observaciones { get; set; }
        public string Cobrado { get; set; }
        public Nullable<decimal> Neto { get; set; }
        public Nullable<int> LiquidacionId { get; set; }
        public string Destinatario { get; set; }
        public string ClienteIdDes { get; set; }
        public Nullable<System.DateTime> Recibida { get; set; }
        public Nullable<int> VNueva { get; set; }
        public Nullable<int> HojadeRuta { get; set; }
    }
}
