using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AguilaDoradaWeb.Models
{
    public class ObjetoVenta
    {
        public Nullable<int> idOrigen { get; set; }
        public Nullable<int> idDestino { get; set; }
        public string fechaViaje { get; set; }
        public Nullable<int> idRecorrido { get; set; }
        public Nullable<decimal> valorPasaje { get; set; }
        public Nullable<int> cantidadPasajeros { get; set; }
        public Nullable<int> numeroAsiento { get; set; }
        public Nullable<int> idServicio { get; internal set; }

    }
}