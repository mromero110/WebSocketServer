﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int Code { get; set; }
    }
}