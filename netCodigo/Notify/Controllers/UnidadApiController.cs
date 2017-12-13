using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Usuario;
using DataAccess.Model;
using Business.Unidad;

namespace Flotilla.Controllers
{
    public class UnidadApiController : ApiController
    {
        private UnidadImplements iUnidad;

        public UnidadApiController()
        {
            iUnidad = new UnidadImplements();
        }

        /// <summary>
        /// En este Post() realiza la insercción de una nueva unidad
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <param name="unidad">Objeto unidad</param>
        /// <returns></returns>
        public HttpResponseMessage Post(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    var actualizaUnidad = iUnidad.ActualizaUnidad(parameters[1].ToString(),Convert.ToDecimal(parameters[2].ToString()), parameters[3].ToString(),Convert.ToDecimal(parameters[4].ToString()));
                    return Request.CreateResponse<string>(HttpStatusCode.OK, actualizaUnidad);
                case "2":
                    var actualizaEstatusLicVIN = iUnidad.ActualizaEstatusLicVIN(parameters[1].ToString(), Convert.ToDecimal(parameters[2].ToString()), parameters[3].ToString());
                    return Request.CreateResponse<decimal>(HttpStatusCode.OK, actualizaEstatusLicVIN);
                case "3":
                    var deleteUnidad = iUnidad.DeleteUnidadPropiedad(parameters[1].ToString(), Convert.ToDecimal(parameters[2].ToString()), parameters[3].ToString(), Convert.ToDecimal(parameters[4].ToString()));
                    return Request.CreateResponse<string>(HttpStatusCode.OK, deleteUnidad);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
                                            
        }

        /// <summary>
        /// En este Get() se obtiene la unidad con el vin y los documentos, fases y permisos por perfil
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    var unidad = iUnidad.GetUnidad(parameters[1]);
                    return Request.CreateResponse<SEL_UNIDAD_SP_Result>(HttpStatusCode.OK, unidad);
                case "4":
                    var encabezado = iUnidad.GetUnidadEncabezado(parameters[1].ToString());
                    return Request.CreateResponse<SEL_UNIDAD_ENCABEZADO_SP_Result>(HttpStatusCode.OK, encabezado);
                case "5":
                    var rolDoc = iUnidad.getRolDocumento();
                    return Request.CreateResponse<IEnumerable<SEL_ROL_DOCUMENTO_SP_Result>>(HttpStatusCode.OK, rolDoc);
                case "6":
                    var docs = iUnidad.getListaDocumentos(parameters[1].ToString(), Convert.ToDecimal(parameters[2].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_LISTA_DOCUMENTOS_SP_Result>>(HttpStatusCode.OK, docs);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);               
        }

        
        /// <summary>
        /// Este metodo Put() se realiza la actualización de la unidad
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <param name="unidad">Objeto unidad</param>
        /// <returns></returns>
        public HttpResponseMessage Put(Unidad unidad)
        {
            // actualización de la unidad                                                                        
            if(ModelState.IsValid)
            {                
                var Unidad = iUnidad.UpdateUnidad(unidad);
                return Request.CreateResponse<Decimal>(HttpStatusCode.OK, Unidad);
            } 
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }         
        }
    }
}
