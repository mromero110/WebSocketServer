using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class SecureZoneResponse 
    {
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public double Presicion { get; set; }
        public int Rango { get; set; }
        public bool Estado { get; set; }
    }
}