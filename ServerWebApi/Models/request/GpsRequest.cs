﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class GpsRequest 
    {
        public int IdDispositivo { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Prescicion { get; set; }
    }
}