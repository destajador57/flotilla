using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Bitacora;
using Business.Utilidades;
using DataAccess.Model;

namespace Flotilla.Controllers
{
    public class BitacoraApiController : ApiController
    {
        Utilidades objUtilidades = new Utilidades();
        private BitacoraImplements iBitacora;

        public BitacoraApiController()
        {
            iBitacora = new BitacoraImplements();
        }

        public HttpResponseMessage Post(string id)
        {
            try
            {
                var parameters = id.Split('|');
                switch (parameters[0])
                {
                    case "1":
                        var BitacoraInsert = iBitacora.InsertaBitacora(int.Parse(parameters[1].ToString()), parameters[2].ToString(), parameters[3].ToString(), Convert.ToInt32(parameters[4]));
                        return Request.CreateResponse<Decimal>(HttpStatusCode.OK, BitacoraInsert);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                objUtilidades.LogErrores(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        public HttpResponseMessage Get(string id)
        {
            try
            {
                var parameters = id.Split('|');
                switch (parameters[0])
                {
                    case "1":
                        var BitacoraConsulta = iBitacora.ConsultaBitacora(int.Parse(parameters[1].ToString()), parameters[2].ToString());
                        return Request.CreateResponse<List<SEL_BITACORA_SP_Result>>(HttpStatusCode.OK, BitacoraConsulta);                       
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                objUtilidades.LogErrores(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
