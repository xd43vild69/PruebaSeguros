using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Entidad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
