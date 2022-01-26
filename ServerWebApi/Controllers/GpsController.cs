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

        // GET: api/gps/5
        [HttpGet]
        [Route("{dispositivo}")]
        public MessageResponse Get(int dispositivo)
        {
            try
            {
                var result = _api.GetHistory(dispositivo);
                return MessageResponse.Ok();
            }
            catch (Exception ex)
            {
                return MessageResponse.Bad(ex.Message);
            }
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
    }
}
