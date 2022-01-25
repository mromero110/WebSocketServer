using ServerWebApi.Models.enty;
using ServerWebApi.Models.request;
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
            using (var context = new SvaiotEntities()) {
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
    }
}