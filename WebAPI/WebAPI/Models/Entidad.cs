using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Entidad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        public bool estado { get; set; }
    }
}
