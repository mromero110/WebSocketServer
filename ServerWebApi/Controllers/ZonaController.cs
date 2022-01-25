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
    [RoutePrefix("api/zona")]
    public class ZonaController : ApiController
    {
        private ZoneServices _api = new ZoneServices();

        // GET: api/zona/wifi/5
        [HttpGet]
        [Route("wifi/{device}")]
        public IHttpActionResult GetWifiZone(int device)
        {
            var result = _api.GetWifiZoneByDevice(device);
            return Ok(result);
        }

        // GET: api/zona/segura/5
        
        [HttpGet]
        [Route("segura/{device}")]
        public IHttpActionResult GetSecureZone(int device)
        {
            var result = _api.GetSecureZoneByDevice(device);
            return Ok(result);
        }

        // PUT: api/zona/wifi
        
        [HttpPost]
        [Route("wifi")]
        public void PostWifiZone([FromBody] WifiZoneRequest zone)
        {
            _api.PostWifiZone(zone);
        }

        // PUT: api/zona/segura
       
        [HttpPost]
        [Route("segura")]
        public void PostSecureZone([FromBody] SecureZoneRequest zone)
        {
            _api.PostSecureZone(zone);
        }
    }
}
