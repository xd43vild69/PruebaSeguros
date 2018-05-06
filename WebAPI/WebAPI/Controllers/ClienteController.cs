using System.Collections.Generic;
using System.Web.Http;
using WebAPI.DAL;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {

        //private PersonaRepositorio _repo;
        private RepositorioCliente<Cliente> repositorio;

        public ClienteController()
        {
            repositorio = new RepositorioCliente<Cliente>();
        }

        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            return repositorio.Listar();
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {
            repositorio.Insertar(cliente);
        }

        // PUT: api/Cliente/5
        public void Put([FromBody]Cliente cliente)
        {
            repositorio.Actualizar(cliente);
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            repositorio.Eliminar(id);
        }
    }
}
