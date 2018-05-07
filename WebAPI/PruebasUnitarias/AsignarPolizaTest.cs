using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI.BLL;
using WebAPI.Controllers;
using WebAPI.DAL;
using WebAPI.Models;

namespace PruebasUnitarias
{
    [TestClass]
    public class AsignarPolizaTest
    {
        
        [TestMethod]
        public void ValidacionPorcentajeCubrimientoPosible()
        {

            Poliza poliza = new Poliza {
                TipoCubrimiento =1,
                TipoRiesgo= "BAJO"
            };
            
            TipoCubrimiento tipoCubrimiento = new TipoCubrimiento
            {
                Id = 1,
                PorcentajeCubrimiento = 40
            };

            var mockSet = new Mock<IRepositorio<TipoCubrimiento>>();

            bool esValido = false;

            var validaciones = new Validaciones(mockSet.Object);

            mockSet.Setup(x => x.BuscarPorId(It.IsAny<int>())).Returns(tipoCubrimiento);
            
            esValido = validaciones.validarPorcentajeCubrimiento(poliza);

            Assert.IsTrue(esValido);

        }

    }
}
