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
    public class ClienteController : Controller
    {

        [Authorize]
        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<Models.Cliente> clienteList;
            HttpResponseMessage response = GlobalVariables.webApiCliente.GetAsync("cliente").Result;
            clienteList = response.Content.ReadAsAsync<IEnumerable<Cliente>>().Result;
            return View(clienteList);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                // Permite validar si las reglas del modelo son validas
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PostAsJsonAsync("cliente", cliente).Result;
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                //TODO: log novedades
            }
            return View();
        }

        [Authorize]
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente cliente = null;

            using (var httpCliente = new HttpClient())
            {
                var respuesta = GlobalVariables.webApiCliente.GetAsync("cliente?id=" + id.ToString());
                respuesta.Wait();

                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerResultado = resultado.Content.ReadAsAsync<Cliente>();
                    leerResultado.Wait();

                    cliente = leerResultado.Result;
                }

            }

            return View(cliente);
        }

        [Authorize]
        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.webApiCliente.PutAsJsonAsync("cliente", cliente).Result;
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
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = null;

            using (var httpCliente = new HttpClient())
            {
                var respuesta = GlobalVariables.webApiCliente.GetAsync("cliente?id=" + id.ToString());
                respuesta.Wait();

                var resultado = respuesta.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var leerResultado = resultado.Content.ReadAsAsync<Cliente>();
                    leerResultado.Wait();

                    cliente = leerResultado.Result;
                }

            }

            return View(cliente);
        }

        [Authorize]
        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.webApiCliente.DeleteAsync("cliente?id=" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult AsignarPoliza(int id)
        {
            return RedirectToAction("Index/" + id.ToString(), "AsignarPoliza");
        }
    }
}