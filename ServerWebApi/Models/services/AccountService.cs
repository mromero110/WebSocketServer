using ServerWebApi.Models.enty;
using ServerWebApi.Models.helper;
using ServerWebApi.Models.request;
using ServerWebApi.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWebApi.Models.services
{
    public class AccountService
    {
        public UserResponse GetUserByCredentials(CredentialRequest credential)
        {
            var usuario_encriptado = CryptoHelper.Encode(credential.CrypUsername);
            var contrasena_encriptada = CryptoHelper.Encode(credential.CrypPassword);
            using (var context = new SvaiotEntities())
            {
                return context.usuario_credenciales
                     .Where(m => m.cryp_username == usuario_encriptado && m.cryp_password == contrasena_encriptada)
                     .Select(m => new UserResponse()
                     {
                         Id = m.id_usuario,
                         Nombre = m.usuario.nombre
                     })
                     .FirstOrDefault();
            }
        }
    }
}