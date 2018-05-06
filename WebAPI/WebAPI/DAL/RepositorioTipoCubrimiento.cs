using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class RepositorioTipoCubrimiento<T> : IRepositorio<T> where T : Entidad, new()
    {
        public void Actualizar(T entidad)
        {
            throw new NotImplementedException();
        }

        public T BuscarPorId(int id)
        {
            using (var db = new DAL.DALContexto())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(T entidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Listar()
        {
            using (var db = new DAL.DALContexto())
            {
                return db.Set<T>().ToList();
            }
        }

    }
}