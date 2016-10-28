using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.BLL.DTO;
using AutoMapper;
using UAIBay.WebSite.ViewModel;
using PagedList;

namespace UAIBay.WebSite.Controllers
{
    public class ProveedorController : Controller
    {
        //
        // GET: /Proveedor/
        public ActionResult Index(int? page)
        {
            var bllProveedor = new dtoProveedor();
            var proveedores = bllProveedor.TraerProveedores();
            App_Start.AutoMapperWebConfiguration.Configure();

            var proveedorViewmodel = Mapper.Map<List<ProveedorViewModels>>(proveedores);
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(proveedorViewmodel.ToPagedList(pageNumber, 9));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProveedorViewModels proveedor)
        {
            if (ModelState.IsValid)
            {
                var DTO = Mapper.Map<ProveedorViewModels, dtoProveedor>(proveedor);

                var BLL = new dtoProveedor();
                BLL.Crear(DTO);

                return RedirectToAction("Index");
            }
            else
            { 
                return View(proveedor);
            }
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var bll = new dtoProveedor();
            var proveedor = bll.BuscarUnProveedor(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProveedor, ProveedorViewModels>(proveedor);
            return View(vmodel);
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            var bll = new dtoProveedor();
            var proveedor = bll.BuscarUnProveedor(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProveedor, ProveedorViewModels>(proveedor);
            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Edit(ProveedorViewModels proveedor)
        {
            if (ModelState.IsValid)
            {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoProveedor DTO = Mapper.Map<ProveedorViewModels, dtoProveedor>(proveedor);

                var bll = new dtoProveedor();
                bll.Actualizar(DTO);

                return RedirectToAction("Index");
            }
            else
            {
                return View(proveedor);
            }
        }

        


        [HttpGet]
        public ActionResult Delete(string id)
        {
            var bll = new dtoProveedor();
            var proveedor = bll.BuscarUnProveedor(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProveedor, ProveedorViewModels>(proveedor);
            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Delete(ProveedorViewModels proveedor)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            dtoProveedor dtoProveedor = Mapper.Map<ProveedorViewModels, dtoProveedor>(proveedor);

            var bll = new dtoProveedor();
            bll.Eliminar(dtoProveedor);

            return RedirectToAction("Index");
        }
         
	}
}