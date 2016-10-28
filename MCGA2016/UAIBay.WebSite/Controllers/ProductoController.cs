using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.WebSite.ViewModel;
using AutoMapper;
using UAIBay.BLL.DTO;
using PagedList;

namespace UAIBay.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int? page)
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(productosVM.ToPagedList(pageNumber, 9));
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
            var bll = new dtoProducto();

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

            bll.Crear(DTO);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Details(int id)
        {
            var bll = new dtoProducto();
            var producto = bll.BuscarUnProducto(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProducto, ProductoViewModels>(producto);
            return View(vmodel);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bll = new dtoProducto();
            var pr = bll.BuscarUnProducto(id);

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProducto, ProductoViewModels>(pr);
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();
            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Edit(ProductoViewModels producto)
        {
            if (ModelState.IsValid)
            {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoProducto DTO = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

                var bll = new dtoProducto();
                bll.Actualizar(DTO);

                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bll = new dtoProducto();
            var producto = bll.BuscarUnProducto(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProducto, ProductoViewModels>(producto);
            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Delete(ProductoViewModels producto)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            var dtopro = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

            var bll = new dtoProducto();
            bll.Eliminar(dtopro);

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