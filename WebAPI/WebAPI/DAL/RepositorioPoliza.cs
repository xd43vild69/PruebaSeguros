using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class RepositorioPoliza<T> : IRepositorio<T> where T : Entidad, new()
    {
        public void Actualizar(T entidad)
        {
            using (var db = new DAL.DALContexto())
            {
                db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
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
            using (var db = new DAL.DALContexto())
            {
                var entidad = new T() { Id = id };
                db.Entry(entidad).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Insertar(T entidad)
        {
            using (var db = new DAL.DALContexto())
            {
                db.Entry(entidad).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
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