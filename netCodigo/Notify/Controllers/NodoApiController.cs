using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Model;
using Business.Nodo;
using Business.RolPermiso;
using Entity.RolPermisosEntity;

namespace Flotilla.Controllers
{
    public class NodoApiController : ApiController
    {
        private NodoImplements iNodo; 

        public NodoApiController()
        {
            iNodo = new NodoImplements();
        }

        /// <summary>
        /// En este Get() se obtienen los documentos, fases y permisos por perfil
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {                
                case "1":
                    // Obtiene las fases y los permisos por perfil
                    var fasePermiso = iNodo.GetFasePermiso(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_FASE_PERMISO_SP_Result>>(HttpStatusCode.OK, fasePermiso);
                case "2":
                    // Obtiene los documentos por fase y permisos de cada perfil
                    var docFasePermiso = iNodo.GetDocFasePermiso(int.Parse(parameters[1].ToString()), int.Parse(parameters[2].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_DOCFASE_PERMISO_SP_Result>>(HttpStatusCode.OK, docFasePermiso);
                case "3":
                    var ConsultaRolPermiso = iNodo.getRolPermiso(int.Parse(parameters[1].ToString()), parameters[2].ToString());
                    return Request.CreateResponse<IEnumerable<SEL_PERMISOS_SP_Result>>(HttpStatusCode.OK, ConsultaRolPermiso);
                case "4":
                    var valor = iNodo.getPdf(parameters[1].ToString());
                    return Request.CreateResponse<object>(HttpStatusCode.OK, valor);

            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

      
    }
}
