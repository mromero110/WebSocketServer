using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
using ServerWebApi.Models.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;


namespace ServerWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        private readonly AccountService _api = new AccountService();

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(CredentialRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userAuth = _api.GetUserByCredentials(login);
            if (userAuth != null)
            {
                var token = SecurityService.GenerateTokenJwt(userAuth);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
