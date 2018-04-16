using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4Proyecto.Models
{
    public class PaisString
    {
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Faltantes")]
        public string faltantes { get; set; }
        [Display(Name = "Coleccionadas")]
        public string coleccionadas { get; set; }
        [Display(Name = "Cambios")]
        public string cambios { get; set; }
    }
}