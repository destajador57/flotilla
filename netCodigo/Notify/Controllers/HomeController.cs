using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net;


namespace Flotilla.Controllers
{

    
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

    }
}
