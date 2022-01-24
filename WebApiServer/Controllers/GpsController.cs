using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using WebApiServer.Models;
using WebApiServer.Models.DTO;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsController : ControllerBase
    {

        private IGgpsManager gps = new GpsManager();

        // GET api/<GpsController>/5
        [HttpGet("{dispositivo}")]
        public List<GpsDTO> Get(int dispositivo)
        {
            List<GpsDTO> lista = new List<GpsDTO>();

            var gps = new GpsDTO
            {
                Longitud = "40",
                Prescicion = "40",
                Latitud = "40"
            };
            lista.Add(gps);
            lista.Add(gps);
            lista.Add(gps);
            lista.Add(gps);
            lista.Add(gps);
            lista.Add(gps);

            return lista;
            // return gps.GetHistory(dispositivo);
        }

        // POST api/<GpsController>/5
        [HttpPost]
        public void Post([FromBody] GpsDTO value, int dispositivo)
        {
            gps.Save(value, dispositivo);
        }
    }
}
