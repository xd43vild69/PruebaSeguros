using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Entidad
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Inactivo")]
        public bool Estado { get; set; }
    }
}