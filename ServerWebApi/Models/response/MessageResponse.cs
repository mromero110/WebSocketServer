using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.response
{
    public class MessageResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public static MessageResponse Ok()
        {
            return new MessageResponse
            {
                Status = true,
                Message = ""
            };
        }

        public static MessageResponse Bad(string message)
        {
            return new MessageResponse
            {
                Status = false,
                Message = message
            };
        }
    }
}