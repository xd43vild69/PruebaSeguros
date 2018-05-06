﻿using System.Collections.Generic;

namespace WebAPI.DAL
{
    interface IRepositorio<T>
    {
        IEnumerable<T> Listar();
        T BuscarPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}