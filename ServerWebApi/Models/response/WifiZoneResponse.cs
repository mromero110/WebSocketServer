using ServerWebApi.Models.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class WifiZoneResponse
    {
        public string Nombre { get; set; }
        public bool EsFisico { get; set; }
        public string Serial { get; set; }
        public bool Estado { get; set; }
    }
}