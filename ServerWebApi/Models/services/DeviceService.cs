using ServerWebApi.Models.enty;
using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.services
{
    public class DeviceService
    {
        public void PostDevice(DeviceRequest device, int usuario)
        {
            using (var context = new SvaiotEntities()) {
                var dispositivo = new dispositivo()
                {
                    id_usuario = usuario,
                    id_serial = device.idSerial,
                    descripcion = device.Descripcion,
                    nombre = device.Nombre,
                    placa  = device.Placa,
                };
                context.dispositivo.Add(dispositivo);
                context.SaveChanges();
            }
        }

        public MessageResponse PostConfiguracion(int dispositivo, ConfigRequest config, int usuario)
        {
            using (var context = new SvaiotEntities())
            {
                var exists = context.dispositivo.Any(m => m.id_usuario == usuario && m.id == dispositivo);
                if (exists)
                {
                    context.add_device_configuration(dispositivo, config.ZonaWifi, config.ApagadoEmergencia, config.Alarma, config.Camara);
                    return MessageResponse.Ok();
                }
                else {
                    return MessageResponse.Bad("El dispositivo no se encuentra asignado");
                }
            }
        }

        public ConfigRequest GetConfiguracion(int device, string serial)
        {
            using (var context = new SvaiotEntities())
            {
               return (from config in context.dispositivo_configuracion
                 where config.dispositivo.id == device && config.dispositivo.dispositivo_serial.serial_device == serial
                 select new ConfigRequest()
                 {
                     Alarma = config.alarma,
                     ApagadoEmergencia = config.apagado_emergencia,
                     Camara = config.camara,
                     ZonaWifi = config.zonawifi
                 }).FirstOrDefault();
            }
        }
    }
}