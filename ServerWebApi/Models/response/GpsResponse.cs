﻿using ServerWebApi.Models.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models
{
    public class GpsResponse : GpsRequest
    {
        public long Id { get; set; }
        public DateTime Genera { get; set; }
    }
}