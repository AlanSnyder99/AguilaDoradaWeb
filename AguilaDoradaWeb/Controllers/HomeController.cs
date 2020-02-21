using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AguilaDoradaWeb.Models.Servicios;
using AguilaDoradaWeb.Models;
using System.Text.RegularExpressions;

namespace AguilaDoradaWeb.Controllers
{
    public class HomeController : Controller
    {
        myContext ctx = new myContext();
        PasajeServicio pasajeServicio = new PasajeServicio();
        List<Cliente> pasajerosDelViaje = new List<Cliente>();
        ObjetoVenta objetoVenta = new ObjetoVenta();

        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        public JsonResult GetSearchValue(string search)
        {
           
            var allSearch = ctx.Parada.Where(x => x.Nombre.Contains(search)).Take(10).ToList().Select(x => new Parada
            {
                Id = x.Id,
                Nombre = x.Nombre
            });

            return new JsonResult { Data = allSearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult BuscarPasaje(Pasaje pasajeBuscado)
        {
            string origen = pasajeBuscado.origen;
            string destino = pasajeBuscado.destino;
            string fecha = pasajeBuscado.fecha;
            string fechaLimpia = Regex.Replace(fecha, "[^0-9A-Za-z]", "", RegexOptions.None);
            int cantidad = pasajeBuscado.cantidadPasajeros;

            Parada paradaOrigen = pasajeServicio.buscarParada(origen);

            Parada paradaDestino = pasajeServicio.buscarParada(destino);



            if (paradaOrigen is null | paradaDestino is null)
            {
                // Pass the error on to the error page.
                ViewBag.listadoServicios = null;
                return View();
            }
            else
            {
                Session.Remove("objetoVenta");

                var listadoServicios = ctx.ServiciosEnVentaGet(fechaLimpia, paradaOrigen.Id, paradaDestino.Id);

                ViewBag.listadoServicios = listadoServicios;

                int idOrigen = paradaOrigen.Id;
                int idDestino = paradaDestino.Id;
                ViewData["idOrigen"] = idOrigen;
                ViewData["idDestino"] = idDestino;

                if (Session["objetoVenta"] != null)
                {
                    ObjetoVenta objetoVenta = (ObjetoVenta)Session["objetoVenta"];
                    objetoVenta.fechaViaje = fechaLimpia;
                    Session["objetoVenta"] = objetoVenta;
                }
                else
                {
                    objetoVenta.fechaViaje = fechaLimpia;
                    Session["objetoVenta"] = objetoVenta;
                }



            }
            return View();
        }

        public ActionResult seleccionarAsientos(int? Id, int vehiculoId, int recorridoId, int idOrigen, int idDestino)
        {
            var listadoAsientos = ctx.PlantillaHorizontalGet(Id, vehiculoId, recorridoId, idOrigen, idDestino);

            ViewData["recorridoId"] = recorridoId;
            ViewData["idOrigen"] = idOrigen;
            ViewData["idDestino"] = idDestino;

           
            if (Session["objetoVenta"] != null)
            {
                ObjetoVenta objetoVenta = (ObjetoVenta)Session["objetoVenta"];

                var servicioSeleccioando = ctx.ServiciosEnVentaGet(objetoVenta.fechaViaje, idOrigen, idDestino);
                foreach(var item in servicioSeleccioando)
                {
                    objetoVenta.valorPasaje = item.Precio;
                }
                objetoVenta.idOrigen = idOrigen;
                objetoVenta.idDestino = idDestino;
                objetoVenta.idRecorrido = recorridoId;
                Session["objetoVenta"] = objetoVenta;
            }
            else
            {
                var servicioSeleccioando = ctx.ServiciosEnVentaGet(objetoVenta.fechaViaje, idOrigen, idDestino);
                foreach (var item in servicioSeleccioando)
                {
                    objetoVenta.valorPasaje = item.Precio;
                    objetoVenta.idServicio = item.ServicioId;
                }
                objetoVenta.idOrigen = idOrigen;
                objetoVenta.idDestino = idDestino;
                objetoVenta.idRecorrido = recorridoId;
                Session["objetoVenta"] = objetoVenta;
            }

            ViewBag.listadoAsientos = listadoAsientos;
     
            return View();

        }


        public void guardarAsientos([FromBody]ListaAsientosDto asientos)
        {
            Session.Remove("listaAsientos");

            List<int> listadoAsientos = asientos.asientos_id;


            Session["listaAsientos"] = listadoAsientos;

        }

        public ActionResult cargarPasajeros()
        {
            

           // ViewBag.pasajerosDelViaje = Session["pasajerosDelViaje"];

            ViewBag.listadoAsientos = Session["listaAsientos"];

            return View();
        }

        public ActionResult buscarClientes(int dni)
        {
            //   int totalPasajeros = pasajero.dni.Count;
            // List<Cliente> pasajerosDelViaje = new List<Cliente>();
            //int clienteProcedure = ctx.ClienteDNIGet(dni);
            Cliente cliente = pasajeServicio.buscarCliente(dni);

            if (cliente == null)
            {
                
                return View("buscarClientes"); //ES DONDE SE CARGA EL CLIENTE
            }
            else
            {
                if (Session["pasajerosDelViaje"] != null)
                {
                    List<Cliente> pasajerosDelViaje = (List<Cliente>)Session["pasajerosDelViaje"];
                    pasajerosDelViaje.Add(cliente);
                    Session["pasajerosDelViaje"] = pasajerosDelViaje;
                }
                else
                {
                    pasajerosDelViaje.Add(cliente);
                    Session["pasajerosDelViaje"] = pasajerosDelViaje;
                }
                
   

                ViewBag.pasajerosDelViaje = Session["pasajerosDelViaje"];
                ViewBag.listadoAsientos = Session["listaAsientos"];
                return View("cargarPasajeros");
            }


          
        }

        [HttpPost]
        public ActionResult cargarCliente(Cliente clienteACargar)
        {
            clienteACargar.Alta = DateTime.Now;
            clienteACargar.TipoDocumentoId = 1;

            pasajeServicio.guardarCliente(clienteACargar);

            Cliente cliente = pasajeServicio.buscarCliente(clienteACargar.Documento.Value);

            if(Session["pasajerosDelViaje"] != null)
            {
                List<Cliente> pasajerosDelViaje = (List<Cliente>)Session["pasajerosDelViaje"];
                pasajerosDelViaje.Add(cliente);
                Session["pasajerosDelViaje"] = pasajerosDelViaje;
            }
            else
            {
                pasajerosDelViaje.Add(cliente);
                Session["pasajerosDelViaje"] = pasajerosDelViaje;
            }

            ViewBag.pasajerosDelViaje = Session["pasajerosDelViaje"];
            ViewBag.listadoAsientos = Session["listaAsientos"];
            return View("cargarPasajeros");
        }

        //var listadoAsientos = ctx.PlantillaHorizontalGet(Id, vehiculoId, recorridoId, idOrigen, idDestino);


        public ActionResult GeneradorVenta()
        {

            if (Session["objetoVenta"] != null)
            {
                ObjetoVenta objetoVenta = (ObjetoVenta)Session["objetoVenta"];

                List<Cliente> pasajerosDelViaje = (List<Cliente>)Session["pasajerosDelViaje"];
                List<int> listaAsientos = (List<int>)Session["listaAsientos"];
                int cantPasajeros = pasajerosDelViaje.Count;
                objetoVenta.cantidadPasajeros = cantPasajeros;
                Cliente primerCliente = pasajerosDelViaje.First();
                var importeTotal = objetoVenta.valorPasaje * objetoVenta.cantidadPasajeros;
                Session["objetoVenta"] = objetoVenta;

               // var venta = pasajeServicio.ventaInsert();
                var venta = ctx.VentaInsert(/*Usuario*/"Local", /*Empleado id*/1, /*Cliente Id*/primerCliente.Id, /*Descuento*/0, /*Bonificacion*/0, /*precioAbs*/importeTotal, /*agenicaId*/1, /*fecha venta*/DateTime.Now, /*importe*/importeTotal,/*abierto 0*/"0",/*con tarjeta importe*/importeTotal,/*tipo desc string*/"nada", /*Canje num*/0).Single();
            
                //  CREO UNA LISTA CONJUNTA DE CLIENTES Y ASIENTOS
                var clientesConAsientos = pasajerosDelViaje.Zip(listaAsientos, (cliente, asiento) => new {idCliente = cliente, idAsiento = asiento });

                foreach (var ca in clientesConAsientos)
                {
                    var tickets = ctx.TicketInsert(ca.idAsiento, objetoVenta.idOrigen,objetoVenta.idDestino, objetoVenta.idServicio,DateTime.Now, primerCliente.Id, 1, venta, 1,objetoVenta.idRecorrido,importeTotal,"Test Localhost","Local", "Local",1,1).ToList();
                }


                ctx.SaveChanges();
            }
            else
            {
                List<Cliente> pasajerosDelViaje = (List<Cliente>)Session["pasajerosDelViaje"];
                List<int> listaAsientos = (List<int>)Session["listaAsientos"];
                int cantPasajeros = pasajerosDelViaje.Count;
                objetoVenta.cantidadPasajeros = cantPasajeros;
                Cliente primerCliente = pasajerosDelViaje.First();
                var importeTotal = objetoVenta.valorPasaje * objetoVenta.cantidadPasajeros;
                Session["objetoVenta"] = objetoVenta;

                var venta = ctx.VentaInsert(/*Usuario*/"Local", /*Empleado id*/1, /*Cliente Id*/primerCliente.Id, /*Descuento*/0, /*Bonificacion*/0, /*precioAbs*/importeTotal, /*agenicaId*/1, /*fecha venta*/DateTime.Now, /*importe*/importeTotal,/*abierto 0*/"0",/*con tarjeta importe*/importeTotal,/*tipo desc string*/"nada", /*Canje num*/0).Single();

                //  CREO UNA LISTA CONJUNTA DE CLIENTES Y ASIENTOS
                var clientesConAsientos = pasajerosDelViaje.Zip(listaAsientos, (cliente, asiento) => new { idCliente = cliente, idAsiento = asiento });

                foreach (var ca in clientesConAsientos)
                {
                    var tickets = ctx.TicketInsert(ca.idAsiento, objetoVenta.idOrigen, objetoVenta.idDestino, objetoVenta.idServicio, DateTime.Now, primerCliente.Id, 1, venta, 1, objetoVenta.idRecorrido, importeTotal, "Test Localhost", "Local", "Local", 1, 1).ToList();
                }

                ctx.SaveChanges();
            }

            return View("Pagar");
        }

        public ActionResult Pagar()
        {
            return View();
        }
        
    }
}