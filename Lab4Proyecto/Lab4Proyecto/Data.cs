using Lab4Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4Proyecto
{
    public class Data
    {
        private static Data Instance;
        public static Data instance
        {

            get
            {
                if (Instance == null)
                {
                    Instance = new Data();
                }
                return Instance;
            }
            set { Instance = value; }
        }

        public Dictionary<string,Pais> Diccionario1=new Dictionary<string, Pais>();
        public Dictionary<string, bool> Diccionario2=new Dictionary<string, bool>();                
    }
}