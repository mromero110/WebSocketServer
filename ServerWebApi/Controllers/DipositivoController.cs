using ServerWebApi.Models.request;
using ServerWebApi.Models.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerWebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/dispositivo")]
    public class DipositivoController : AuthController
    {
        private readonly DeviceService _api = new DeviceService();

        // POST: api/dipositivo
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostDevice([FromBody]DeviceRequest device)
        {
            var response = _api.PostDevice(device,AuthUser.Id);
            return Ok(response);
        }

        // PUT: api/dipositivo/{id}/configuracion
        [Route("{id}/configuracion")]
        public IHttpActionResult PostConfiguracion(int id, [FromBody]ConfigRequest config)
        {
            var response = _api.PostConfiguracion(id,config, AuthUser.Id);
            return Ok(response);
        }

    }
}
