using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;

namespace UAIBay.WebSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            var productosTopDiez = productosVM.Take(10).ToList();
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);
            ViewBag.Categorias = categoriasViewmodel;

            return View(productosTopDiez);
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