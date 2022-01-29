using ServerWebApi.Models;
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
    [RoutePrefix("api/gps")]
    public class GpsController : ApiController
    {
        private readonly GpsService _api = new GpsService();

        // GET: api/gps/5/history
        [HttpGet]
        [Route("{dispositivo}")]
        public List<GpsResponse> Get(int dispositivo)
        {
            return _api.GetHistory(dispositivo);
        }

        // POST: api/gps
        [HttpPost]
        [Route("")]
        public MessageResponse Post([FromBody]GpsRequest gps)
        {
            try
            {
                _api.Save(gps);
                return MessageResponse.Ok();
            }
            catch (Exception ex)
            {
                return MessageResponse.Bad(ex.Message);
            }
        }

        // POST: api/gps
        [HttpGet]
        [Route("zonasegura/{dispositivo}")]
        public MessageResponse ValidarZonaSegura([FromBody] LatLangRequest posicion, int dispositivo) {
            return _api.ValidarZonaSegura(dispositivo, posicion);
        }
    }
}
