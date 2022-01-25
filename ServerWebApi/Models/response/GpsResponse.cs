using ServerWebApi.Models.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models
{
    public class GpsResponse
    {
        public long Id { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Prescicion { get; set; }
        public DateTime Genera { get; set; }
    }
}