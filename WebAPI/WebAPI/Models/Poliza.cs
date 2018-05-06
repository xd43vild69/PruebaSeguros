using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Poliza : Entidad
    {

        public string Descripcion { get; set; }

        [Required]
        public int TipoCubrimiento { get; set; }

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

        //TODO: [Required]
        //public List<String> tipoRiesgo { get; set; }

        //public IEnumerable<TipoDeRiesgo> tipoDeRiesgo { get; set; }

        public int ClienteId { get; set; }

    }
}