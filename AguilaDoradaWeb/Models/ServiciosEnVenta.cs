using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AguilaDoradaWeb.Models
{
    public class ServiciosEnVenta
    {

        public int RecorridoId { get; set; }
        public int Id { get; set; }
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public int VehiculoId { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Recorrido { get; set; }
        public string Observaciones { get; set; }
        public DateTime Salida { get; set; }
        public DateTime Llegada { get; set; }
        public int LineaId { get; set; }
        public string Linea { get; set; }
        public int Precio { get; set; }
        public int Ocupacion { get; set; }
        public int TarifaId { get; set; }
        public string Hora { get; set; }
        public bool Disca { get; set; }
        public bool ConGPS { get; set; }
        public int GPS { get; set; }
        public int Dias { get; set; }
        public int Descuento { get; set; }
        public int DiasV { get; set; }
        public bool LowCost { get; set; }

    }
}