﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SVAIOT_Database
{
    public partial class Gps
    {
        public long Id { get; set; }
        public int IdDispositivo { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Prescicion { get; set; }
        public DateTime Genera { get; set; }

        public virtual Dispositivo IdDispositivoNavigation { get; set; }
    }
}