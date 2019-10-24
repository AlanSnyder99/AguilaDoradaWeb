using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AguilaDoradaWeb.Models
{
    public class Pasaje
    {
        public string origen { get; set; }
        public string destino { get; set; }
        public string fecha { get; set; }
        public int cantidadPasajeros { get; set; }


    }
}