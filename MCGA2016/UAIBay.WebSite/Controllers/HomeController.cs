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

        [HttpPost]
        public ActionResult Email(String txtemail, String txtnombre, String txtapellido, String txtmensaje)
        {
            UAIBay.Servicios.CorreoElectronico.EnviarCorreo(txtemail, txtnombre + txtapellido, txtmensaje, "CONSULTA PRODUCTO");

            return View("EmailEnviado");
        }
	}
}