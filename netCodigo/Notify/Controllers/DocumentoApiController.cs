using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Business.Documento;
using System.Web.Http;
using DataAccess.Model;
using System.Net.Http;

namespace Flotilla.Controllers
{
    public class DocumentoApiController : ApiController
    {

        private DocumentoImplements iDocumento;

        public DocumentoApiController()
        {
            iDocumento = new DocumentoImplements();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(string id)
        {
            //string VIN,Decimal idDocumento,string Ruta,string Formato
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":// Guarda Documento en otra ruta y cambia nombre ""Genera la estructura
                    var Documento = iDocumento.GuardaDocumento(parameters[1].ToString(), int.Parse(parameters[2].ToString()), parameters[3].ToString(), parameters[4].ToString());
                    return Request.CreateResponse<string>(HttpStatusCode.OK, Documento);
                
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public byte[] Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":// Activa Usuario
                    var pdfCartaFactura = iDocumento.CartaFactura(parameters[1].ToString(), int.Parse(parameters[2].ToString()), int.Parse(parameters[3].ToString()), parameters[4].ToString(), parameters[5].ToString(), parameters[6].ToString(), parameters[7].ToString(), parameters[8].ToString(), parameters[9].ToString());
                    return pdfCartaFactura;
            }
            return null;
        }

    }
}
