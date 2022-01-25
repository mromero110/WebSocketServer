using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.request
{
    public class CredentialRequest
    {
        public string CrypUsername { get; set; }
        public string CrypPassword { get; set; }
    }
}