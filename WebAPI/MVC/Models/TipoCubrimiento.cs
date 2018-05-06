using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class TipoCubrimiento: Entidad
    {
        [Display(Name = "Porcentaje")]
        public int PorcentajeCubrimiento { get; set; }
    }
}