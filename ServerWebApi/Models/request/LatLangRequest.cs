using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class LatLangRequest
    {
        public float Latitud { get; set; }
        public float Longitud { get; set; }
    }
}