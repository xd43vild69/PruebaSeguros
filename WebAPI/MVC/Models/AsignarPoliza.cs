using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AsignarPoliza
    {
        public List<Models.Cliente> ClientesLista { get; set; }

        public List<Models.Poliza> PolizasLista { get; set; }

        [Display(Name = "ID Asignación")]
        public int id { get; set; }

        [Display(Name = "ID Cliente")]
        public int clienteId { get; set; }
    }
}