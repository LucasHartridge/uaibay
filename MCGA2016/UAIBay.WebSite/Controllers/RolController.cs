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
    public class RolController : Controller
    {
        //
        // GET: /Rol/
        public ActionResult Index(int? page)
        {
            var bll = new dtoRoles();
            var roles = bll.TraerRoles();
            App_Start.AutoMapperWebConfiguration.Configure();

            var rolesVM = Mapper.Map<List<RolesViewModels>>(roles);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(rolesVM.ToPagedList(pageNumber, 9));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RolesViewModels rol)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<RolesViewModels, dtoRoles>(rol);

                var bll = new dtoRoles();
                bll.Crear(dto);

                return RedirectToAction("Index");
            }
            else
            {
                return View(rol);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var bll = new dtoRoles();
            var rol = bll.BuscarRol(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var rolVM = Mapper.Map<dtoRoles, RolesViewModels>(rol);
            return View(rolVM);
        }

        [HttpPost]
        public ActionResult Edit(RolesViewModels rol)
        {
            if (ModelState.IsValid)
            {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoRoles dtoRoles = Mapper.Map<RolesViewModels, dtoRoles>(rol);

                var bll = new dtoRoles();
                bll.Actualizar(dtoRoles);

                return RedirectToAction("Index");
            }
            else
            {
                return View(rol);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bll = new dtoRoles();
            var rol = bll.BuscarRol(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var rolVM = Mapper.Map<dtoRoles, RolesViewModels>(rol);
            return View(rolVM);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bll = new dtoRoles();
            var rol = bll.BuscarRol(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var rolVM = Mapper.Map<dtoRoles, RolesViewModels>(rol);
            return View(rolVM);
        }

        [HttpPost]
        public ActionResult Delete(RolesViewModels rol)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            dtoRoles dtoRoles = Mapper.Map<RolesViewModels, dtoRoles>(rol);

            var bll = new dtoRoles();
            bll.Eliminar(dtoRoles);

            return RedirectToAction("Index");
        }



	}
}