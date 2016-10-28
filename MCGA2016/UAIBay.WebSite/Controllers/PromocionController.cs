using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;
using PagedList;

namespace UAIBay.WebSite.Controllers
{
    public class PromocionController : Controller
    {
        //
        // GET: /Promocion/
        public ActionResult Index(int? page)
        {

            var bll = new dtoPromocion();
            var promocionesVigentes = bll.TraerPromociones();
            App_Start.AutoMapperWebConfiguration.Configure();

            var promocionesVM = Mapper.Map<List<PromocionViewModels>>(promocionesVigentes);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(promocionesVM.ToPagedList(pageNumber, 9));
        }


        [HttpGet]
        public ActionResult Create()
        {

            string codigo= RandomString();

            ViewBag.CodDescuento = "UAIBAY" + codigo;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PromocionViewModels promocion)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<PromocionViewModels, dtoPromocion>(promocion);

                var bll = new dtoPromocion();
                bll.Crear(dto);

                return RedirectToAction("Index");
            }
            else
            {
                return View(promocion);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bll = new dtoPromocion();
            var promo = bll.BuscarPromocion(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoPromocion, PromocionViewModels>(promo);
            return View(vmodel);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bll = new dtoPromocion();
            var pr = bll.BuscarPromocion(id);

            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoPromocion, PromocionViewModels>(pr);

            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Edit(PromocionViewModels pr)
        {
            if (ModelState.IsValid)
            {
                App_Start.AutoMapperWebConfiguration.Configure();
                dtoPromocion DTO = Mapper.Map<PromocionViewModels, dtoPromocion>(pr);

                var bll = new dtoPromocion();
                bll.Actualizar(DTO);

                return RedirectToAction("Index");
            }
            else
            {
                return View(pr);
            }
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bll = new dtoPromocion();
            var pr = bll.BuscarPromocion(id);

            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoPromocion, PromocionViewModels>(pr);

            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Delete(PromocionViewModels pr)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            var dtopro = Mapper.Map<PromocionViewModels, dtoPromocion>(pr);

            var bll = new dtoPromocion();
            bll.Eliminar(dtopro);

            return RedirectToAction("Index");
        }



        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }




	}
}