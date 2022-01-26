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
    [RoutePrefix("api/zona")]
    public class ZonaController : ApiController
    {
        private ZoneServices _api = new ZoneServices();

        // GET: api/zona/wifi/5
        [HttpGet]
        [Route("wifi/{device}")]
        public List<WifiZoneResponse> GetWifiZone(int device)
        {
            return _api.GetWifiZoneByDevice(device);
        }

        // GET: api/zona/segura/5
        
        [HttpGet]
        [Route("segura/{device}")]
        public List<SecureZoneResponse> GetSecureZone(int device)
        {
            var result = _api.GetSecureZoneByDevice(device);
            return result;
        }

        // PUT: api/zona/wifi
        
        [HttpPost]
        [Route("wifi")]
        public MessageResponse PostWifiZone([FromBody] WifiZoneRequest zone)
        {
            try
            {
                _api.PostWifiZone(zone);
                return MessageResponse.Ok();
            }
            catch (Exception ex)
            {
                return MessageResponse.Bad(ex.Message);
            }
        }

        // PUT: api/zona/segura
       
        [HttpPost]
        [Route("segura")]
        public MessageResponse PostSecureZone([FromBody] SecureZoneRequest zone)
        {
            try
            {
                _api.PostSecureZone(zone);
                return MessageResponse.Ok();
            }
            catch (Exception ex)
            {
                return MessageResponse.Bad(ex.Message);
            }
        }
    }
}
