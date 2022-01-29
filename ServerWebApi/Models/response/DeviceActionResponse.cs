using ServerWebApi.Models.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class DeviceActionResponse : DeviceActionRequest
    {
        public DateTime Genera { get; set; }

    }
}