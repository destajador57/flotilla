using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.RolPermiso;
using Entity.RolPermisosEntity;

namespace Flotilla.Controllers
{
    public class RolPermisoApiController : ApiController
    {
        private RolPermisoImplements iRolPermiso;

        public RolPermisoApiController()
        {
            iRolPermiso = new RolPermisoImplements();
        }       


    }
}
