using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.WebSite.ViewModel;
using AutoMapper;
using UAIBay.BLL.DTO;

namespace UAIBay.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();
            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            return View(productosVM);
        }




        [HttpGet]
        public ActionResult Create()
        {
            var bll = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bll.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);
            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductoViewModels producto, HttpPostedFileBase imagen)
        {
            producto.Imagen = "prueba";

            var bll = new dtoProducto();

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

            bll.Crear(DTO);


            return RedirectToAction("Index");
        }
















        [HttpGet]
        public ActionResult VerProducto(int? id)
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