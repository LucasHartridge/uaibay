using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.ORM.Business;
using UAIBay.Repository;
using UAIBay.WebSite.ViewModel;

namespace UAIBay.WebSite.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/
        public ActionResult Index()
        {
            var cp = new CategoriaRepository();
            var categorias = cp.ObtenerTodos();
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categorias);
            return View(categoriasViewmodel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaViewModels categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria dtoCategoria = Mapper.Map<CategoriaViewModels, Categoria>(categoria);
                CategoriaRepository cp = new CategoriaRepository();
                cp.Insertar(dtoCategoria);
                cp.Save();
                return RedirectToAction("Index");  
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult Update(int id)
        {
            //Crear Repository
            CategoriaRepository cp = new CategoriaRepository();

            //Creas un View Model con el Id del Update
            Categoria dtoCategoria = new Categoria();
            dtoCategoria = cp.TraerPorId(id);

            //Transformo a ModelView
            CategoriaViewModels categoria = Mapper.Map<Categoria, CategoriaViewModels>(dtoCategoria);
           
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Update(CategoriaViewModels categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria dtoCategoria = Mapper.Map<CategoriaViewModels, Categoria>(categoria);
                CategoriaRepository cp = new CategoriaRepository();
                cp.Actualizar(dtoCategoria);
                cp.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }



	}
}