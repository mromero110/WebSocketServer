using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace ServerWebApi.Controllers
{
    [Authorize]
    public abstract class AuthController : ApiController
    {
        public UserResponse AuthUser { 
            get {
                var identity = (ClaimsPrincipal)HttpContext.Current.User;
                var user = new UserResponse
                {
                    Id = int.Parse(identity.FindFirst(ClaimTypes.Sid).Value),
                    Nombre = identity.FindFirst(ClaimTypes.Name).Value
                };
                return user;
            }
        }
    }
}
