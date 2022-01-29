using ServerWebApi.Models.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class DeviceResponse : DeviceRequest
    {
        public int Id { get; set; }
    }
}