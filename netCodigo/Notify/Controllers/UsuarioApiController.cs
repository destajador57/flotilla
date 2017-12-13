using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net;
using Business.Usuario;
using System.Web.Http;
using DataAccess.Model;

namespace Flotilla.Controllers
{
    public class UsuarioApiController : ApiController
    {
        private UsuarioImplements iUsuario;

        public UsuarioApiController()
        {
            iUsuario = new UsuarioImplements();
        }
        

        public HttpResponseMessage Post(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":// registra usuario Pendiente
                    var Usuario = iUsuario.RegistraUsuarioPendiente(int.Parse(parameters[1].ToString()), parameters[2].ToString(), parameters[3].ToString(), parameters[4].ToString());
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, Usuario);
                case "2":// Activa Usuario
                    var iUsuarioActivo = iUsuario.ActivaUsuario(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, iUsuarioActivo);
                case "3":
                    // Obtiene el usuario con parametros usuario, password
                    var usuario = iUsuario.ValidaUsuario(parameters[1].ToString(), parameters[2].ToString());
                    return Request.CreateResponse<SEL_VALIDAR_USUARIO_SP_Result>(HttpStatusCode.OK, usuario);
                case "4":
                    // Obtiene el usuario con parametros usuario, password
                    var usuariourl = iUsuario.ValidaUsuarioUrl(parameters[1].ToString());
                    return Request.CreateResponse<SEL_VALIDAR_USUARIO_URL_SP_Result>(HttpStatusCode.OK, usuariourl);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// En este put se obtienen los datos del usuario
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Put(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    // Obtiene el usuario con parametros usuario, password
                    var usuario = iUsuario.ValidaUsuario(parameters[1].ToString(), parameters[2].ToString());
                    return Request.CreateResponse<SEL_VALIDAR_USUARIO_SP_Result>(HttpStatusCode.OK, usuario);
            }   
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
