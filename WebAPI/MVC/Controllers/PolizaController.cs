using MVC.Models;
using MVC.ViewModels;
using System;
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
            try
            {
                IEnumerable<Models.Poliza> polizaList;
                HttpResponseMessage response = GlobalVariables.webApiCliente.GetAsync("poliza").Result;
                polizaList = response.Content.ReadAsAsync<IEnumerable<Poliza>>().Result;
                return View(polizaList);
            }
            catch
            {
                //TODO: Log
                return View();
            }

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
            IEnumerable<Models.TipoCubrimiento> tipoDeRiesgos;
            HttpResponseMessage respuesta = GlobalVariables.webApiCliente.GetAsync("tipocubrimiento").Result;
            tipoDeRiesgos = respuesta.Content.ReadAsAsync<IEnumerable<TipoCubrimiento>>().Result;

            PolizaVM poliza = new PolizaVM();

            poliza.TipoCubrimiento = new SelectList(tipoDeRiesgos, "Id", "Nombre");

            return View(poliza);
        }

        [Authorize]
        // POST: Poliza/Create
        [HttpPost]
        public ActionResult Create(Poliza poliza)
        {
            try
            {
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
            try
            {
                PolizaVM poliza = null;

                IEnumerable<Models.TipoCubrimiento> tipoDeRiesgos;
                HttpResponseMessage response = GlobalVariables.webApiCliente.GetAsync("tipocubrimiento").Result;
                tipoDeRiesgos = response.Content.ReadAsAsync<IEnumerable<TipoCubrimiento>>().Result;

                using (var cliente = new HttpClient())
                {
                    var respuesta = GlobalVariables.webApiCliente.GetAsync("poliza?id=" + id.ToString());
                    respuesta.Wait();

                    var resultado = respuesta.Result;
                    if (resultado.IsSuccessStatusCode)
                    {
                        var leerResultado = resultado.Content.ReadAsAsync<Poliza>();
                        leerResultado.Wait();

                        poliza = new PolizaVM
                        {
                            Descripcion = leerResultado.Result.Descripcion,
                            Nombre = leerResultado.Result.Nombre,
                            FechaInicio = leerResultado.Result.FechaInicio,
                            PeridoCobertura = leerResultado.Result.PeridoCobertura,
                            ValorPoliza = leerResultado.Result.ValorPoliza,
                            TipoCubrimiento = new SelectList(tipoDeRiesgos, "Id", "Nombre", leerResultado.Result.TipoCubrimiento)
                        };
                    }
                }

                return View(poliza);
            }
            catch(Exception ex)
            {

                string s = ex.ToString();
                //TODO: Log
                return View();
            }


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
            try
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
            catch
            {
                //TODO: Log
                return View();
            }
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
