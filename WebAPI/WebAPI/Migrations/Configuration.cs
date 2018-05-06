namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI.DAL.DALContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAPI.DAL.DALContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.TiposCubrimientos.AddOrUpdate(x => x.Id,
            new Models.TipoCubrimiento() { Id = 1, PorcentajeCubrimiento = 100, Nombre = "Robo", Estado = false },
            new Models.TipoCubrimiento() { Id = 2, PorcentajeCubrimiento = 50, Nombre = "Terremoto", Estado = false },
            new Models.TipoCubrimiento() { Id = 3, PorcentajeCubrimiento = 20, Nombre = "Incendio", Estado = false },
            new Models.TipoCubrimiento() { Id = 4, PorcentajeCubrimiento = 10, Nombre = "Accidente", Estado = false }
            );

            context.Clientes.AddOrUpdate(x => x.Id,
            new Models.Cliente() { Id = 1, Nombre = "David", Estado = false },
            new Models.Cliente() { Id = 1, Nombre = "Ana", Estado = false }
            );

            context.Polizas.AddOrUpdate(x => x.Id,
            new Models.Poliza() { Id = 1, Nombre = "PolizaCompleta", Estado = false, FechaInicio = System.DateTime.Now, ValorPoliza = 10000, TipoRiesgo = "ALTO", TipoCubrimiento = 1, Descripcion = "Poliza SEED", PeridoCobertura = 12 },
            new Models.Poliza() { Id = 1, Nombre = "PolizaBaja", Estado = false, FechaInicio = System.DateTime.Now, ValorPoliza = 10000, TipoRiesgo = "BAJA", TipoCubrimiento = 4, Descripcion = "Poliza SEED", PeridoCobertura = 6 },
            new Models.Poliza() { Id = 1, Nombre = "PolizaCancelada", Estado = true, FechaInicio = System.DateTime.Now, ValorPoliza = 10000, TipoRiesgo = "BAJA", TipoCubrimiento = 4, Descripcion = "Poliza SEED", PeridoCobertura = 6 }

            );

        }
    }
}
