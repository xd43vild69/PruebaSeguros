using System.Collections.Generic;
using System.Web.Http;
using WebAPI.BLL;
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
            Validaciones validacion = new Validaciones();
            if(validacion.validarPorcentajeCubrimiento(poliza))
            {
                repositorio.Insertar(poliza);
            }else
            {
                //TODO : Implementar excepción de negocio.
            }
        }

        // PUT: api/Poliza/5
        public void Put([FromBody]Poliza poliza)
        {
            Validaciones validacion = new Validaciones();
            if (validacion.validarPorcentajeCubrimiento(poliza))
            {
                repositorio.Actualizar(poliza);
            }
            else
            {
                //TODO : Implementar excepción de negocio.
            }
        }

        // DELETE: api/Poliza/5
        public void Delete(int id)
        {
            repositorio.Eliminar(id);
        }
    }
}
