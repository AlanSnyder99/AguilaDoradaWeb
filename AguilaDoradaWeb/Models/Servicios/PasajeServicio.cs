using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AguilaDoradaWeb.Models;

namespace AguilaDoradaWeb.Models.Servicios
{
    public class PasajeServicio
    {

        myContext ctx = new myContext();


        public Parada buscarParada(string parada)
        {

            Parada paradaBuscada = ctx.Parada.FirstOrDefault(x => x.Nombre == parada);

            return paradaBuscada;

        }

        public List<Cliente> buscarCliente(Pasajero pasajero)
        {
            List<Cliente> Totalclientes = new List<Cliente>();

            foreach (int dni in pasajero.dni)
            {
                //Cliente cliente = ctx.Cliente.SingleOrDefault(x => x.Documento == dni  );
                // var clientes = (from c in ctx.Cliente where c.Documento == dni select c);

                Cliente cliente = ctx.Cliente.First(x => x.Documento == dni);


                if (cliente != null)
                {

                    Totalclientes.Add(cliente);
                }
                else
                {

                }
    
            }

                //List<Cliente> Totalclientes = (from c in ctx.Cliente where pasajero.dni.Contains.(c.Documento) select c).ToList();

                return Totalclientes;

        }


    }

}