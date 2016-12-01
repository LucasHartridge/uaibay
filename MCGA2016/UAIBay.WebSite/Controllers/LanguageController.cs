using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using System.Net.Mail;
using System.Configuration;

namespace UAIBay.WebSite.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(string LanguageAbbreviation)
        {
            if (LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);
            }

            HttpCookie cookie = new HttpCookie("Lenguaje");
            cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(cookie);


            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}