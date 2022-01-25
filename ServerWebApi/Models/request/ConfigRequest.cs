using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class ConfigRequest
    {
        public bool ZonaWifi { get; set; }
        public bool ApagadoEmergencia { get; set; }
        public bool Alarma { get; set; }
        public bool Camara { get; set; }
    }
}