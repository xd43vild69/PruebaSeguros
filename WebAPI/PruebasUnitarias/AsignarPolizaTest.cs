using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.BLL;
using WebAPI.Controllers;
using WebAPI.Models;

namespace PruebasUnitarias
{
    [TestClass]
    public class AsignarPolizaTest
    {
        [TestMethod]
        public void CancelacionPoliza()
        {
            //TODO: validar cancelación.
        }

        [TestMethod]
        public void AsignacionPoliza()
        {
            //TODO: validar asignación poliza cliente.
        }

        [TestMethod]
        public void ValidacionPorcentajeCubrimientoPosible()
        {
            bool esValido = false;

            Poliza poliza = new Poliza();
            poliza.TipoRiesgo = "BAJO";
            poliza.TipoCubrimiento = 1;

            var validaciones = new Validaciones();

            esValido = validaciones.validarPorcentajeCubrimiento(poliza);

            Assert.IsTrue(esValido);

        }

    }
}
