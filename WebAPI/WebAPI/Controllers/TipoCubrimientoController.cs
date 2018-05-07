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
    public class TipoCubrimientoController : ApiController
    {
        private RepositorioTipoCubrimiento<TipoCubrimiento> _repositorio;

        public TipoCubrimientoController()
        {
            _repositorio = new RepositorioTipoCubrimiento<TipoCubrimiento>();
        }

        // GET: api/tiporiesgo
        public IEnumerable<TipoCubrimiento> Get()
        {
            return _repositorio.Listar();
        }
    }
}
