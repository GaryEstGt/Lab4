using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab4Proyecto.Models
{
    public class Calcomania
    {
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Disponibilidad")]
        public string disponibilidad { get; set; }
    }
}