using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net;
using Business.Accesorio;
using System.Web.Http;
using DataAccess.Model;

namespace Flotilla.Controllers
{
    public class AccesorioApiController : ApiController
    {
        private AccesorioImplements iAccesorio;

        public AccesorioApiController()
        {
            iAccesorio = new AccesorioImplements();
        }
        
        /// <summary>
        /// Crea accesorio
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Put(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    var idInsertAccesorio = iAccesorio.InsertaAccesorio(int.Parse(parameters[1].ToString()), int.Parse(parameters[2].ToString()));
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, idInsertAccesorio);
                case "2":
                    var idInsertAccesorioOtro = iAccesorio.InsertaAccesorioOtros(int.Parse(parameters[1].ToString()), parameters[2].ToString());
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, idInsertAccesorioOtro);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Borra Accesorio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {               
                case "1":
                    var idBorraAccesorio = iAccesorio.BorraAccesorio(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, idBorraAccesorio);
                case "2":
                    var idBorraAccesorioOtro = iAccesorio.BorraAccesorioOtro(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, idBorraAccesorioOtro);               
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Consulta Accesorio
        /// </summary>
        /// <param name="id">Dentro de id están todos los parámetros</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    var ConsultaAccesorio = iAccesorio.ConsultaAccesorio(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<List<SEL_ACCESORIO_SP_Result>>(HttpStatusCode.OK, ConsultaAccesorio);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }               
    }
}
