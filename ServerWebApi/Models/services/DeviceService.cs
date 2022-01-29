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
            using (var context = new SvaiotEntities())
            {
                if (!context.dispositivo_serial.Any(m => m.serial_device == device.Serial && m.dispositivo.Any(d => d.id_usuario == usuario))) {
                    var esp = context.dispositivo_serial.Where(m => m.serial_device == device.Serial).FirstOrDefault();
                    if (esp.dispositivo.Count == 0)
                    {
                        esp.dispositivo.Add(new dispositivo()
                        {
                            id_usuario = usuario,
                            descripcion = device.Descripcion,
                            nombre = device.Nombre,
                            placa = device.Placa,
                        });
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El dispositivo ya se encuentra asignado");
                    }
                }
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
                else
                {
                    return MessageResponse.Bad("El dispositivo no se encuentra asignado");
                }
            }
        }

        public List<DeviceActionResponse> GetDeviceActionsHistory(int idUsuario, int idDevice)
        {
            using (var context = new SvaiotEntities())
            {
                var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                return (from action in context.dispositivo_acciones
                        where action.id_dispositivo == idDevice && action.dispositivo.id_usuario == idUsuario
                        where action.genera > now
                        select new DeviceActionResponse()
                        {
                            Estado = action.estado,
                            Genera = action.genera,
                            Latitud = action.latitud,
                            Longitud = action.longitud,
                            Zona = action.zona
                        }).ToList();
            }
        }

        public MessageResponse PostDeviceAction(int idUsuario, int device, string from, DeviceActionRequest action)
        {
            using (var context = new SvaiotEntities())
            {
                var exists = context.dispositivo.Any(m => m.id_usuario == idUsuario && m.id == device);
                if (exists)
                {
                    var data = new dispositivo_acciones()
                    {
                        id_dispositivo = device,
                        estado = from.ToUpper() + " - " + action.Estado,
                        genera = DateTime.Now,
                        latitud = action.Latitud,
                        longitud = action.Longitud,
                        zona = action.Zona
                    };

                    context.dispositivo_acciones.Add(data);
                    context.SaveChanges();
                    return MessageResponse.Ok();
                }
                else
                {
                    return MessageResponse.Bad("El dispositivo no se encuentra asignado");
                }
            }
        }

        public List<DeviceResponse> GetDevices(int idUsuario)
        {
            using (var context = new SvaiotEntities())
            {
                return (from device in context.dispositivo
                        where device.id_usuario == idUsuario
                        select new DeviceResponse()
                        {
                            Id = device.id,
                            Descripcion = device.descripcion,
                            Serial = device.dispositivo_serial.serial_device,
                            Nombre = device.nombre,
                            Placa = device.placa
                        }).ToList();
            }
        }

        public List<DeviceActionResponse> GetDeviceActions(int idUsuario, int idDevice)
        {
            using (var context = new SvaiotEntities())
            {
                var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0,0);
                return (from action in context.dispositivo_acciones
                        where action.id_dispositivo == idDevice && action.dispositivo.id_usuario == idUsuario
                        where action.genera <= now
                        select new DeviceActionResponse()
                        {
                            Estado = action.estado,
                            Genera = action.genera,
                            Latitud = action.latitud,
                            Longitud = action.longitud,
                            Zona = action.zona
                        }).ToList();
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
                            TelefonoEmergencia = config.dispositivo.usuario.telefono,
                            Alarma = config.alarma,
                            ApagadoEmergencia = config.apagado_emergencia,
                            Camara = config.camara,
                            ZonaWifi = config.zonawifi
                        }).FirstOrDefault();
            }
        }
    }
}