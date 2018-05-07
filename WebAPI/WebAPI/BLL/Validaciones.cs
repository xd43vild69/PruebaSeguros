using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.DAL;
using WebAPI.Models;
using WebAPI.Valor;

namespace WebAPI.BLL
{

    /// <summary>
    /// Clase que realiza la lógica de validaciones relacionadas al proceso.
    /// Deberia ir en un componente aparte, pero por cuestiones de tiempo solo se separo aquí.
    /// </summary>
    public class Validaciones
    {

        private IRepositorio<TipoCubrimiento> _repositorio;

        public Validaciones()
        {
            _repositorio = new RepositorioTipoCubrimiento<TipoCubrimiento>();
        }

        public Validaciones(IRepositorio<TipoCubrimiento> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Permite validar si la póliza de seguro contiene una línea riesgo alto,
        /// el porcentaje de cubrimiento no puede ser superior al 50%.
        /// </summary>
        ///<param name="poliza">Clase con la información de la poliza que se busca validar.</param>
        /// <returns>Verdadero si puede crearse la poliza por que pasa la validación.</returns>
        public bool validarPorcentajeCubrimiento(Poliza poliza)
        {
            bool esValido = true;

            int porcentaje = this.buscarPorcentajeTipoCubrimiento(poliza.TipoCubrimiento);
            string tipoRiesgo = poliza.TipoRiesgo;

            if (tipoRiesgo.ToUpper() == Enum.GetName(typeof(TipoRiesgo), 0) && porcentaje > 50)
            {
                esValido = false;
            }

            return esValido;
        }

        public int buscarPorcentajeTipoCubrimiento(int id)
        {
            TipoCubrimiento tipoCubrimiento = _repositorio.BuscarPorId(id);

            return tipoCubrimiento.PorcentajeCubrimiento;
        }
    }
}
