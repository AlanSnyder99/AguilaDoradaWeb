using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AguilaDoradaWeb.Models
{
    public class Pasajero
    {

        public List<string> nombre { get; set;}
        public List<string> apellido { get; set; }
        public List<int> edad { get; set; }
        public List<int> dni { get; set; }
        public List<string> nacionalidad { get; set; }
        public List<string> fechaNacimiento { get; set; }
        public string sexo { get; set; }



    }
}