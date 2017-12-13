using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Business.Rol;
using DataAccess.Model;
namespace Flotilla.Controllers
{
    public class RolApiController : ApiController
    {
        private RolImplements iAccesorio;

        public RolApiController()
        {
            iAccesorio = new RolImplements();
        }

        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":// Activa Usuario
                    var ConsultaRol = iAccesorio.ConsultaRol();
                    return Request.CreateResponse<List<SEL_ROL_TODOS_SP_Result>>(HttpStatusCode.OK, ConsultaRol);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
