using System.Collections.Generic;
using System.Web.Http;
using WebAPI.DAL;
using WebAPI.Models;

namespace testPoliza1.Controllers
{
    public class PolizaController : ApiController
    {
        private RepositorioPoliza<Poliza> repositorio;

        public PolizaController()
        {
            repositorio = new RepositorioPoliza<Poliza>();
        }

        // GET: api/Poliza
        public IEnumerable<Poliza> Get()
        {
            return repositorio.Listar();
        }

        // GET: api/Poliza/5
        public Poliza Get(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        // POST: api/Poliza
        public void Post([FromBody]Poliza poliza)
        {
            repositorio.Insertar(poliza);
        }

        // PUT: api/Poliza/5
        public void Put([FromBody]Poliza poliza)
        {
            repositorio.Actualizar(poliza);
        }

        // DELETE: api/Poliza/5
        public void Delete(int id)
        {
            repositorio.Eliminar(id);
        }
    }
}
