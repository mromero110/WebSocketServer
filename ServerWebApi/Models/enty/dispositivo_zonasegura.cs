//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerWebApi.Models.enty
{
    using System;
    using System.Collections.Generic;
    
    public partial class dispositivo_zonasegura
    {
        public int id { get; set; }
        public int id_dispositivo { get; set; }
        public string nombre { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public double presicion { get; set; }
        public int rango { get; set; }
        public bool estado { get; set; }
    
        public virtual dispositivo dispositivo { get; set; }
    }
}
