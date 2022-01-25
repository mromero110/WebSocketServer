using ServerWebApi.Models;
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
    [RoutePrefix("api/gps")]
    public class GpsController : ApiController
    {
        private readonly GpsService _api = new GpsService();

        // GET: api/gps/5
        [HttpGet]
        [Route("{dispositivo}")]
        public IHttpActionResult Get(int dispositivo)
        {
            var result = _api.GetHistory(dispositivo);
            return Ok(result);
        }

        // POST: api/gps
        [HttpPost]
        [Route("")]
        public void Post([FromBody]GpsRequest gps)
        {
            _api.Save(gps);
        }
    }
}
