using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class DeviceUserResponse
    {
        public int Code { get; set; }
        public UserResponse User { get; set; }
    }
}