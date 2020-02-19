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
                var listadoServicios = ctx.ServiciosEnVentaGet(fechaLimpia, paradaOrigen.Id, paradaDestino.Id);

                ViewBag.listadoServicios = listadoServicios;

                int idOrigen = paradaOrigen.Id;
                int idDestino = paradaDestino.Id;
                ViewData["idOrigen"] = idOrigen;
                ViewData["idDestino"] = idDestino;
            }

        
            return View();
        }

        public ActionResult seleccionarAsientos(int? Id, int vehiculoId, int recorridoId, int idOrigen, int idDestino)
        {
            var listadoAsientos = ctx.PlantillaHorizontalGet(Id, vehiculoId, recorridoId, idOrigen, idDestino);

            ViewData["recorridoId"] = recorridoId;
            ViewData["idOrigen"] = idOrigen;
            ViewData["idDestino"] = idDestino;

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




        public ActionResult Pagar()
        {

           

            return View();
        }
        
    }
}