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
    public class AdminController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Dashboard/
        public ActionResult Visitas()
        {
            ProductModel objProductModel = new ProductModel();
            objProductModel.YearTitle = "Codigo de Producto";
            objProductModel.SaleTitle = "Precio de Venta";
            objProductModel.PurchaseTitle = "Precio de Compra";
            return View(objProductModel);
        }

        public JsonResult GetChart()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);

        return Json(productosVM .Select(p=>new{p.Descripcion, p.PrecioVenta,p.PrecioCompra}),JsonRequestBehavior.AllowGet);
        }
	}

    class ProductModel
    {
        public String YearTitle { get; set; }
        public String SaleTitle { get; set; }
        public String PurchaseTitle { get; set; }

    }
}