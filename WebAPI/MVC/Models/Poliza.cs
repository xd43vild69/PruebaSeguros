using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Poliza: Entidad
    {
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Tipo Cubrimiento")]
        public int TipoCubrimiento { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Periodo Cobertura")]
        [Range(1, 12)]
        public int PeridoCobertura { get; set; }

        [Required]
        [Display(Name = "Valor Poliza")]
        [Range(0, double.MaxValue)]
        public double ValorPoliza { get; set; }

        [Required]
        [Display(Name = "Tipo Cubrimiento")]
        public string TipoRiesgo { get; set; }

        public int ClienteId { get; set; }
    }
}