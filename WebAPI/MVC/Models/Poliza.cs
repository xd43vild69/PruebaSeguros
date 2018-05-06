using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Poliza: Entidad
    {
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Tipo Cubrimiento")]
        public int tipoCubrimiento { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime fechaInicio { get; set; }

        [Required]
        [Display(Name = "Periodo Cobertura")]
        [Range(1, 12)]
        public int peridoCobertura { get; set; }

        [Required]
        [Display(Name = "Valor Poliza")]
        [Range(0, double.MaxValue)]
        public double valorPoliza { get; set; }

        [Required]
        [Display(Name = "Tipo Cubrimiento")]
        public string tipoRiesgo { get; set; }

        public int clienteId { get; set; }
    }
}