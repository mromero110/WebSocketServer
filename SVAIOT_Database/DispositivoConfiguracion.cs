﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SVAIOT_Database
{
    public partial class DispositivoConfiguracion
    {
        public long Id { get; set; }
        public int IdDispositivo { get; set; }
        public bool Zonawifi { get; set; }
        public bool ApagadoEmergencia { get; set; }
        public bool Alarma { get; set; }
        public bool Camara { get; set; }
        public DateTime Genera { get; set; }

        public virtual Dispositivo IdDispositivoNavigation { get; set; }
    }
}