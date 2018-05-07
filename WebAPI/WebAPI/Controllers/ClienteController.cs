using System.Collections.Generic;
using System.Web.Http;
using WebAPI.DAL;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {

        //private PersonaRepositorio _repo;
        private RepositorioCliente<Cliente> _repositorio;

        public ClienteController()
        {
            _repositorio = new RepositorioCliente<Cliente>();
        }

        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            return _repositorio.Listar();
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {
            _repositorio.Insertar(cliente);
        }

        // PUT: api/Cliente/5
        public void Put([FromBody]Cliente cliente)
        {
            _repositorio.Actualizar(cliente);
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            _repositorio.Eliminar(id);
        }
    }
}
