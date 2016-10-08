using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UAIBay.WebSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {



            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult NuestraInformacion()
        {
            return View();
        }
        public ActionResult FAQS()
        {
            return View();
        }
	}
}