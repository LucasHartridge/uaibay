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
<<<<<<< HEAD
        // GET: /Home/
      
        
        public ActionResult VerProducto()
=======
        // GET: /Account/
        public ActionResult Index()
>>>>>>> origin/preMaster
        {
            return View();
        }

<<<<<<< HEAD
        [HttpPost]
        public ActionResult VerProducto(int? id)
        {
            return View();
        }
      
=======
    [HttpPost]
        public ActionResult VerProducto()
        {
            return View();
        }
>>>>>>> origin/preMaster
	}
}