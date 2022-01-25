using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class SecureZoneRequest : SecureZoneResponse
    {
        public int IdDispositivo { get; set; }
    }
}