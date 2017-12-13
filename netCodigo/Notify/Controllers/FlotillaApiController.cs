using Business.Busqueda;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Flotilla.Controllers
{
    public class FlotillaApiController : ApiController
    {
        private FlotillaImplements iFlotilla;

        public FlotillaApiController()
        {
            iFlotilla = new FlotillaImplements();
        }

        /// <summary>
        /// En este get se obtienen los datos de la flotilla 
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    // Obtiene la flotilla tiene los parametros factura o vin
                    var flotilla = iFlotilla.BusquedaFlotilla(parameters[1].ToString(), parameters[2].ToString(), null, parameters[3].ToString());
                    return Request.CreateResponse<IEnumerable<SEL_BUSQUEDA_FLOTILLA_SP_Result>>(HttpStatusCode.OK, flotilla);
                case "2":
                    // Obtiene la licitacion para la app
                    var licitacion = iFlotilla.LicitacionApp();
                    return Request.CreateResponse<IEnumerable<SEL_LICITACION_APP_SP_Result>>(HttpStatusCode.OK, licitacion);
                case "3":
                    // Obtiene la licitacion para la app
                    var persona = iFlotilla.GetPersona(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_PERSONA_PUESTO_SP_Result>>(HttpStatusCode.OK, persona);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}