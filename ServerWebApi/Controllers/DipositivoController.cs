using ServerWebApi.Models.helper;
using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
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
        public MessageResponse PostDevice([FromBody] DeviceRequest device)
        {
            try
            {
                _api.PostDevice(device, AuthUser.Id);
                return MessageResponse.Ok();
            }
            catch (Exception ex) 
            {
                return MessageResponse.Bad(ex.Message);
            }
        }

        // PUT: api/dipositivo/5/configuracion
        [HttpPost]
        [Route("{id}/configuracion")]
        public MessageResponse PostConfiguracion(int id, [FromBody] ConfigRequest config)
        {
            try
            {
                var response = _api.PostConfiguracion(id, config, AuthUser.Id);
                return MessageResponse.Ok();
            }
            catch (Exception ex)
            {
                return MessageResponse.Bad(ex.Message);
            }
        }


        // Get: api/dipositivo/8
        [HttpGet]
        [Route("{device}/serial/{codigo}")]
        public ConfigRequest GetConfiguracion(int device, string codigo)
        {
            var serial = CryptoHelper.Decode(codigo);
            return _api.GetConfiguracion(device, serial);
        }
    }
}
