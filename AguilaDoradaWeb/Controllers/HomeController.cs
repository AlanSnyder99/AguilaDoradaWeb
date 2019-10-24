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

        public ActionResult Index()
        {
         
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

        public ActionResult cargarPasajeros()
        {

            ViewBag.listadoAsientos = Session["listaAsientos"];

            return View();
        }

        public void guardarAsientos([FromBody]ListaAsientosDto asientos)
        {

            List<int> listadoAsientos = asientos.asientos_id;

            Session["listaAsientos"] = listadoAsientos;

        }

        public ActionResult buscarClientes(Pasajero pasajero)
        {
            int totalPasajeros = pasajero.dni.Count;

            List<Cliente> Totalclientes = pasajeServicio.buscarCliente(pasajero);

            if (Totalclientes == null)
            {
                ViewBag.clientesACargar = totalPasajeros;
            }
            else
            {
                int totalPasajerosCargar = totalPasajeros - Totalclientes.Count;

                ViewBag.clientesACargar = totalPasajerosCargar;
                ViewBag.clientes = Totalclientes;
            }


            return View();
        }

    

        public ActionResult Pagar(Pasajero pasajeros)
        {

           

            return View();
        }
        
    }
}