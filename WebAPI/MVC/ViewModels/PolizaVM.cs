using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.ViewModels
{
    public class PolizaVM : Entidad
    {
        public string Descripcion { get; set; }

        [Required]
        //public int TipoCubrimiento { get; set; }
        public IEnumerable<SelectListItem> TipoCubrimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Required]
        public int PeridoCobertura { get; set; }

        [Required]
        public double ValorPoliza { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoRiesgo { get; set; }

        public IEnumerable<SelectListItem> TiposRiesgo { get; set; }

        //public IEnumerable<TipoDeRiesgo> tipoDeRiesgo { get; set; }

        public int ClienteId { get; set; }
    }
}