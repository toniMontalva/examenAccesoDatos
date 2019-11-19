using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Leagues
    {
        // Ejercicio 1
        public String Abreviatura { get; set; }
        public String Nombre { get; set; }

        public Leagues(String ab, String name)
        {
            Abreviatura = ab;
            Nombre = name;
        }

        // Fin ejercicio 1
    }
}