using ServerWebApi.Models.enty;
using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.services
{
    public class ZoneServices
    {
        public void PostWifiZone(WifiZoneRequest request)
        {
            using (var context = new SvaiotEntities())
            {
                var zone = new dispositivo_zonawifi
                {
                    id_dispositivo = request.IdDispositivo,
                    es_fisico = request.EsFisico,
                    nombre = request.Nombre,
                    estado = request.Estado,
                    serial = request.Serial
                };
                context.dispositivo_zonawifi.Add(zone);
                context.SaveChanges();
            }
        }

        public void PostSecureZone(SecureZoneRequest request)
        {
            using (var context = new SvaiotEntities())
            {
                var zone = new dispositivo_zonasegura()
                {
                    id_dispositivo = request.IdDispositivo,
                    latitud = request.Latitud,
                    longitud = request.Longitud,
                    nombre = request.Nombre,
                    presicion = request.Presicion,
                    rango = request.Rango,
                    estado = request.Estado,
                };
                context.dispositivo_zonasegura.Add(zone);
                context.SaveChanges();
            }
        }

        public List<WifiZoneResponse> GetWifiZoneByDevice(int device)
        {
            using (var context = new SvaiotEntities())
            {
                return (from wifi in context.dispositivo_zonawifi
                        where wifi.id_dispositivo == device
                        select new WifiZoneResponse()
                        {
                            EsFisico = wifi.es_fisico,
                            Estado = wifi.estado,
                            Nombre = wifi.nombre,
                            Serial = wifi.serial
                        }).ToList();
            }
        }

        public List<SecureZoneResponse> GetSecureZoneByDevice(int device)
        {
            using (var context = new SvaiotEntities())
            {
                return (from secure in context.dispositivo_zonasegura
                        where secure.id_dispositivo == device
                        select new SecureZoneResponse()
                        {
                            Estado = secure.estado,
                            Nombre = secure.nombre,
                            Latitud = secure.latitud,
                            Longitud = secure.longitud,
                            Presicion = secure.presicion,
                            Rango = secure.rango
                        }).ToList();
            }
        }
    }
}