using ServerWebApi.Models.enty;
using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerWebApi.Models.services
{
    public class GpsService
    {
        public List<GpsResponse> GetHistory(int dispositivo)
        {
            using (var context = new SvaiotEntities())
            {

                return (from gps in context.gps
                        where gps.id_dispositivo == dispositivo
                        where !gps.latitud.Equals("0")
                        select new GpsResponse()
                        {
                            Latitud = gps.latitud,
                            Longitud = gps.longitud,
                            Prescicion = gps.prescicion,
                            Genera = gps.genera,
                            Id = gps.id
                        }).ToList();
            }
        }

        public void Save(GpsRequest gps)
        {
            using (var context = new SvaiotEntities())
            {
                var data = new gps
                {
                    genera = DateTime.Now,
                    longitud = gps.Longitud,
                    latitud = gps.Latitud,
                    prescicion = gps.Prescicion,
                    id_dispositivo = gps.IdDispositivo
                };
                context.gps.Add(data);
                context.SaveChanges();
            }
        }

        public MessageResponse ValidarZonaSegura(int dispositivo, LatLangRequest posicion)
        {
            using (var context = new SvaiotEntities())
            {
                var result = context.validate_securezone(posicion.Latitud, posicion.Longitud, dispositivo).FirstOrDefault();
                if (result != null)
                {
                    var message = "Se encuentra en la zona " + result.nombre + " a " + Math.Ceiling(result.distance.Value) + " metros ";
                    return MessageResponse.Ok(message);
                }
                else
                {
                    return MessageResponse.Bad("Fuera de zona segura");
                }
            }
        }
    }
}