using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.Servicios;
using UAIBay.WebSite.ViewModel;

namespace UAIBay.WebSite.Controllers
{
    [Autorizaciones.AutorizarUsuarioYAdmin]
    public class DireccionController : Controller
    {

        [HttpPost]
        public ActionResult Create(string provincia, string partido, string direccion, int codigo)
        {
            var bll = new dtoDireccion();

            DireccionViewModels direccionVM = new DireccionViewModels()
            {
                CodigoPostal = codigo.ToString(),
                Domicilio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(direccion),
                Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(partido),
                Provincia = provincia
            };

            var idU = Convert.ToInt32(Session["LogedUserID"]);

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<DireccionViewModels, dtoDireccion>(direccionVM);

            bll.Crear(DTO, idU);


            return RedirectToAction("Carrito", "Comprar", new { userId = idU });
        }

    }
}