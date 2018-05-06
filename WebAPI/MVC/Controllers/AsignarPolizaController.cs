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
            IEnumerable<Models.Poliza> polizaList;
            HttpResponseMessage response2 = GlobalVariables.webApiCliente.GetAsync("poliza").Result;
            polizaList = response2.Content.ReadAsAsync<IEnumerable<Poliza>>().Result;

            AsignarPoliza asignarPolizar = new AsignarPoliza();

            Session["clienteId"] = id;

            asignarPolizar.clienteId = id;
            asignarPolizar.PolizasLista = polizaList.ToList();

            return View(asignarPolizar);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Cancelar(AsignarPoliza asignarPoliza)
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

            poliza.estado = true;

            try
            {

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index/" + poliza.clienteId);
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
        public ActionResult Asignar(int id, AsignarPoliza asignarPoliza)
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

            poliza.clienteId = (int)Session["clienteId"];

            //TODO: asignar cliente a la poliza seleccionada
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index/" + poliza.clienteId);
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