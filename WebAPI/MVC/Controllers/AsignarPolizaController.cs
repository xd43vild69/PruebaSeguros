using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    public class AsignarPolizaController : Controller
    {

        [Authorize]
        [HttpGet]
        // GET: AsignarPoliza
        public ActionResult Index(int id)
        {
            try
            {
                IEnumerable<Models.Poliza> polizaLista;
                HttpResponseMessage response2 = GlobalVariables.webApiCliente.GetAsync("poliza").Result;
                polizaLista = response2.Content.ReadAsAsync<IEnumerable<Poliza>>().Result;

                AsignarPoliza asignarPolizar = new AsignarPoliza();

                asignarPolizar.clienteId = id;
                asignarPolizar.PolizasLista = polizaLista.ToList();

                return View(asignarPolizar);
            }
            catch
            {
                //TODO: Log
                return View();
            }

        }

        [Authorize]
        [HttpGet]
        public ActionResult Cancelar(AsignarPoliza asignarPoliza)
        {
            try
            {
                Poliza poliza = new Poliza();

                using (var cliente = new HttpClient())
                {
                    var respuesta = GlobalVariables.webApiCliente.GetAsync("poliza?id=" + asignarPoliza.id);
                    respuesta.Wait();

                    var resultado = respuesta.Result;
                    if (resultado.IsSuccessStatusCode)
                    {
                        var leerResultado = resultado.Content.ReadAsAsync<Poliza>();
                        leerResultado.Wait();

                        poliza = leerResultado.Result;
                    }

                }

                poliza.Estado = true;

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index/" + poliza.ClienteId);
                }
            }
            catch
            {
                //TODO:LOG
            }
            return RedirectToAction("Index/" + (int)Session["clienteId"]);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Asignar(int id, int clienteId)
        {

            //TODO: asignar cliente a la poliza seleccionada
            try
            {
                Poliza poliza = new Poliza();

                using (var cliente = new HttpClient())
                {
                    var respuesta = GlobalVariables.webApiCliente.GetAsync("poliza?id=" + id);
                    respuesta.Wait();

                    var resultado = respuesta.Result;
                    if (resultado.IsSuccessStatusCode)
                    {
                        var leerResultado = resultado.Content.ReadAsAsync<Poliza>();
                        leerResultado.Wait();

                        poliza = leerResultado.Result;
                    }

                }

                poliza.ClienteId = clienteId;

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index/" + poliza.ClienteId);
                }
            }
            catch
            {
                //TODO:LOG
            }
            return View();

        }

    }
}