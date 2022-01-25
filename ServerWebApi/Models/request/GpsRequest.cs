using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class GpsRequest : GpsResponse
    {
        public int IdDispositivo { get; set; }
    }
}