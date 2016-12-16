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




        [HttpGet]
        public ActionResult CreateDir()
        {

            var provincias = ProvinciasFill.CargarProvincias();

            ViewBag.Provincia = provincias.Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value = x.ToString()
            });

            return View();
        }

        [HttpPost]
        public ActionResult CreateDir(string dom, string loc, string provincia, int cp)
        {

            var bll = new dtoDireccion();

            DireccionViewModels direccionVM = new DireccionViewModels()
            {
                CodigoPostal = cp.ToString(),
                Domicilio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dom),
                Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(loc),
                Provincia = provincia
            };

            var idU = Convert.ToInt32(Session["LogedUserID"]);

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<DireccionViewModels, dtoDireccion>(direccionVM);

            bll.Crear(DTO, idU);


            return RedirectToAction("MisDirecciones", "Account");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bll = new dtoUsuario();
            var usuario = bll.BuscarCuenta(Convert.ToInt32(Session["LogedUserID"]));

            var dir = usuario.Direccion.Where(x => x.IDDireccion == id).FirstOrDefault();

            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoDireccion, DireccionViewModels>(dir);

            var provincias = ProvinciasFill.CargarProvincias();

            ViewBag.Provincia = provincias.Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value = x.ToString()
            });

            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Edit(DireccionViewModels dir)
        {

            DireccionViewModels direccionVM = new DireccionViewModels()
            {
                CodigoPostal = dir.CodigoPostal.ToString(),
                Domicilio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dir.Domicilio),
                Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dir.Localidad),
                Provincia = dir.Provincia,
                IDDireccion = dir.IDDireccion,
                UserId = dir.UserId
            };

            App_Start.AutoMapperWebConfiguration.Configure();
            dtoDireccion DTO = Mapper.Map<DireccionViewModels, dtoDireccion>(direccionVM);

            var bll = new dtoDireccion();
            bll.Actualizar(DTO);

            return RedirectToAction("MisDirecciones", "Account");

        }

        public ActionResult Delete(int id)
        {
            var bll = new dtoUsuario();
            var usuario = bll.BuscarCuenta(Convert.ToInt32(Session["LogedUserID"]));

            var dir = usuario.Direccion.Where(x => x.IDDireccion == id).FirstOrDefault();

            var bllD = new dtoDireccion();
            bllD.Eliminar(dir);

            return RedirectToAction("MisDirecciones", "Account");
        }
    }
}