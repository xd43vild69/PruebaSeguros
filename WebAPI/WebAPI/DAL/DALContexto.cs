﻿using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class DALContexto : DbContext
    {
        public DALContexto() : base("CadenaDeConexion")
        {
        }

        public DbSet<Poliza> Polizas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<TipoDeRiesgo> TipoDeRiegos { get; set; }

        public DbSet<TipoCubrimiento> TiposCubrimientos { get; set; }
    }
}