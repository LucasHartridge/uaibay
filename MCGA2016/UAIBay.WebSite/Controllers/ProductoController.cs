using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UAIBay.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

    [HttpPost]
        public ActionResult VerProducto()
        {
            return View();
        }
	}
}