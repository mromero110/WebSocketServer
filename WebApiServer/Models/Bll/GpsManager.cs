using SVAIOT_Database;
using System.Linq;
using System.Collections.Generic;
using WebApiServer.Models.DTO;
using System;

namespace WebApiServer.Models
{

    public interface IGgpsManager {
        void Save(GpsDTO gps, int dispositivo);
        List<GpsDTO> GetHistory(int dispositivo);
    }

    public class GpsManager : IGgpsManager
    {
        public List<GpsDTO> GetHistory(int dispositivo)
        {
            using var context = new SvaiotContext();
            return (from gps in context.Gps
                    where gps.IdDispositivo == dispositivo
                    select new GpsDTO()
                    {
                        Latitud = gps.Latitud,
                        Longitud = gps.Longitud,
                        Prescicion = gps.Prescicion
                    }).ToList();
        }

        public void Save(GpsDTO gps, int dispositivo)
        {
            using var context = new SvaiotContext();
            var data = new Gps
            {
                Genera = DateTime.Now,
                Longitud = gps.Longitud,
                Latitud = gps.Latitud,
                Prescicion = gps.Prescicion,
                IdDispositivo = dispositivo
            };
            context.Gps.Add(data);
            context.SaveChanges();
        }
    }
}
