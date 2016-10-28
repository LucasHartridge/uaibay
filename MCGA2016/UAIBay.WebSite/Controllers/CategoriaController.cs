using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.WebSite.ViewModel;
using UAIBay.BLL.DTO;
using PagedList;

namespace UAIBay.WebSite.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/
        public ActionResult Index(int? page)
        {
            var bllCategoria = new dtoCategoria();
            var categorias = bllCategoria.TraerCategorias();
            App_Start.AutoMapperWebConfiguration.Configure();

            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categorias);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(categoriasViewmodel.ToPagedList(pageNumber, 9));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaViewModels categoria)
        {
            if (ModelState.IsValid)
            {
                var dtoCategoria = Mapper.Map<CategoriaViewModels, dtoCategoria>(categoria);

                var bllCategoria = new dtoCategoria();
                bllCategoria.Crear(dtoCategoria);

                return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var bllCategoria = new dtoCategoria();
            var categoria = bllCategoria.BuscarCategoria(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var categoriasViewmodel = Mapper.Map<dtoCategoria,CategoriaViewModels>(categoria);
            return View(categoriasViewmodel);
        }

        [HttpPost]
        public ActionResult Update(CategoriaViewModels categoria)
        {
            if (ModelState.IsValid)
            {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoCategoria dtoCategoria = Mapper.Map<CategoriaViewModels, dtoCategoria>(categoria);

                var bllCategoria = new dtoCategoria();
                bllCategoria.Actualizar(dtoCategoria);

                return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bllCategoria = new dtoCategoria();
            var categoria = bllCategoria.BuscarCategoria(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var categoriasViewmodel = Mapper.Map<dtoCategoria, CategoriaViewModels>(categoria);
            return View(categoriasViewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bllCategoria = new dtoCategoria();
            var categoria = bllCategoria.BuscarCategoria(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var categoriasViewmodel = Mapper.Map<dtoCategoria, CategoriaViewModels>(categoria);
            return View(categoriasViewmodel);
        }

        [HttpPost]
        public ActionResult Delete(CategoriaViewModels categoria)
        {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoCategoria dtoCategoria = Mapper.Map<CategoriaViewModels, dtoCategoria>(categoria);

                var bllCategoria = new dtoCategoria();
                bllCategoria.Eliminar(dtoCategoria);

                return RedirectToAction("Index");
        }



    }
}