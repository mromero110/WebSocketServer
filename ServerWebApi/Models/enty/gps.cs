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
    
    public partial class gps
    {
        public long id { get; set; }
        public int id_dispositivo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string prescicion { get; set; }
        public System.DateTime genera { get; set; }
    
        public virtual dispositivo dispositivo { get; set; }
    }
}
