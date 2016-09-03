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
        // GET: /Home/
      
        
        public ActionResult VerProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerProducto(int? id)
        {
            return View();
        }
      
	}
}