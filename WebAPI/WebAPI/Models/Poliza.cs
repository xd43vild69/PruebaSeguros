using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Poliza : Entidad
    {

        public string descripcion { get; set; }

        [Required]
        public int tipoCubrimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaInicio { get; set; }

        [Required]
        public int peridoCobertura { get; set; }

        [Required]
        public double valorPoliza { get; set; }

        [Required]
        [StringLength(100)]
        public string tipoRiesgo { get; set; }

        //TODO: [Required]
        //public List<String> tipoRiesgo { get; set; }

        //public IEnumerable<TipoDeRiesgo> tipoDeRiesgo { get; set; }

        public int clienteId { get; set; }

    }
}