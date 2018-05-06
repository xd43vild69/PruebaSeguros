using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.DAL;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TipoRiesgoController : ApiController
    {
        private RepositorioTipoDeRiesgo<TipoDeRiesgo> repositorio;

        public TipoRiesgoController()
        {
            repositorio = new RepositorioTipoDeRiesgo<TipoDeRiesgo>();
        }

        // GET: api/tiporiesgo
        public IEnumerable<TipoDeRiesgo> Get()
        {
            return repositorio.Listar();
        }

    }
}
