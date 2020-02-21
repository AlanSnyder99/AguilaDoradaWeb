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

        public void guardarClientes(List<Cliente> listaClientesCargados)
        {
            foreach(Cliente cliente in listaClientesCargados)
            {
                ctx.Cliente.Add(cliente);
                ctx.SaveChanges();
            }
        }
        public void guardarCliente(Cliente clienteACargar)
        { 
                ctx.Cliente.Add(clienteACargar);
                ctx.SaveChanges();
        }

        public Cliente buscarCliente(int dni)
        {
          //  Cliente ClienteBuscado = new Cliente();

            Cliente cliente = ctx.Cliente.FirstOrDefault(x => x.Documento == dni);
        

                if (cliente != null)
                {
                    cliente.Apellido = cliente.Apellido ?? "";
                    cliente.Domicilio = cliente.Domicilio ?? "";
                    cliente.Email = cliente.Email ?? "";
                    cliente.passwd = cliente.passwd ?? "";
                    cliente.Telefono = cliente.Telefono ?? "";
                    cliente.LocalidadId = cliente.LocalidadId ?? 0;
                    cliente.SexoId = cliente.SexoId ?? 0;
                    cliente.FechaNacimiento = cliente.FechaNacimiento ?? DateTime.Now;



                }
                else
                {
                return null;
                }
    
                return cliente;

        }



    }

}