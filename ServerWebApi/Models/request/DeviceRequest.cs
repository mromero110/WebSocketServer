using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class DeviceRequest
    {
        public string Serial { get; set; }
        public string Nombre { get; set; }
        public string Placa { get; set; }
        public string Descripcion { get; set; }
    }
}