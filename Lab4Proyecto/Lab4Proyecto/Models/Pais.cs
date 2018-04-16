using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab4Proyecto.Models
{
    public class Pais
    {
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Faltantes")]
        public List<int> faltantes { get; set; }
        [Display(Name = "Coleccionadas")]
        public List<int> coleccionadas { get; set; }
        [Display(Name = "Cambios")]
        public List<int> cambios { get; set; }

        public string faltantesToString()
        {
            string faltan = "";
            for (int i = 0; i < faltantes.Count; i++)
            {
                faltan += faltantes[i];
                if (i != faltantes.Count - 1)
                {
                    faltan += ", ";
                }
            }

            return faltan;
        }
        public string coleccionadasToString()
        {
            string coleccion = "";
            for (int i = 0; i < coleccionadas.Count; i++)
            {
                coleccion += coleccionadas[i];
                if (i != coleccionadas.Count - 1)
                {
                    coleccion += ", ";
                }
            }

            return coleccion;
        }
        public string cambiosToString()
        {
            string cambio = "";
            for (int i = 0; i < cambios.Count; i++)
            {
                cambio += cambios[i];
                if (i != cambios.Count - 1)
                {
                    cambio += ", ";
                }
            }

            return cambio;
        }
    }
}