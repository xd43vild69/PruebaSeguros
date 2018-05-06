using MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class PolizaController : Controller
    {
        [Authorize]
        // GET: Poliza
        public ActionResult Index()
        {
            IEnumerable<Models.Poliza> polizaList;
            HttpResponseMessage response = GlobalVariables.webApiCliente.GetAsync("poliza").Result;
            polizaList = response.Content.ReadAsAsync<IEnumerable<Poliza>>().Result;
            return View(polizaList);
        }

        [Authorize]
        // GET: Poliza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Poliza/Create
        public ActionResult Create()
        {

            return View();
        }

        [Authorize]
        // POST: Poliza/Create
        [HttpPost]
        public ActionResult Create(Poliza poliza)
        {
            try
            {
                // TODO: Add insert logic here
                // Permite validar si las reglas del modelo son validas
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PostAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                //TODO: log novedades
            }
            return View();
        }

        // GET: Poliza/Edit/5
        public ActionResult Edit(int id)
        {

            Poliza poliza = null;

            using (var cliente = new HttpClient())
            {
                var respuesta = GlobalVariables.webApiCliente.GetAsync("poliza?id=" + id.ToString());
                respuesta.Wait();

                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerResultado = resultado.Content.ReadAsAsync<Poliza>();
                    leerResultado.Wait();

                    poliza = leerResultado.Result;
                }

            }

            return View(poliza);
        }

        [Authorize]
        // POST: Poliza/Edit/5
        [HttpPost]
        public ActionResult Edit(Poliza poliza)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("poliza", poliza).Result;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //TODO:LOG
            }
            return View();
        }

        [Authorize]
        // GET: Poliza/Delete/5
        public ActionResult Delete(int id)
        {
            Poliza poliza = null;

            using (var cliente = new HttpClient())
            {
                var respuesta = GlobalVariables.webApiCliente.GetAsync("poliza?id=" + id.ToString());
                respuesta.Wait();

                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerResultado = resultado.Content.ReadAsAsync<Poliza>();
                    leerResultado.Wait();

                    poliza = leerResultado.Result;
                }

            }

            return View(poliza);

        }

        [Authorize]
        // POST: Poliza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.webApiCliente.DeleteAsync("poliza?id=" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
