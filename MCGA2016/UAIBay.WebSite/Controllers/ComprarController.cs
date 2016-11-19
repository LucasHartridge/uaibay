using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;
using System.IO;

namespace UAIBay.WebSite.Controllers
{
    public class ComprarController : Controller
    {
        //
        // GET: /Comprar/
        public ActionResult Catalogo()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();

            return View(productosVM);

        }

        public ActionResult AgregarItem(int codProducto)
        {
            int idCarrito = Convert.ToInt32(Session["logeduserid"]);

            var bll = new dtoCarrito();

            bll.AgregarProducto(codProducto, idCarrito);

            return RedirectToAction("Carrito", new { userId = idCarrito });
        }



        public ActionResult QuitarItem(int codProducto)
        {

            int nroCarrito = Convert.ToInt32(Session["logeduserid"]);

            var bll = new dtoCarrito();

            bll.QuitarProducto(codProducto, nroCarrito);

            return RedirectToAction("Carrito", new { userId = nroCarrito });
        }

        public ActionResult Carrito(int userId)
        {
            var bll = new dtoCarrito();
            var carrito = bll.TraerCarrito(userId);

            if (carrito==null)
            {

                bll.CrearCarrito(new dtoCarrito (){ UserId = userId, IdCarrito = userId });
                carrito = bll.TraerCarrito(userId);
            }

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var carritoVM = Mapper.Map<dtoCarrito, CarritoViewModels>(carrito);
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();
            ViewBag.Carrito = carrito.IdCarrito;

            return View("Carrito", carritoVM.ItemCarrito);

        }


        public ActionResult Comprar()
        {

            int nroCarrito = Convert.ToInt32(Session["logeduserid"]);

            // FALTA COMPROBAR CODIGO DE DESCUENTO

            var bll = new dtoCarrito();
            bll.RealizarCompra(nroCarrito);
            return RedirectToAction("CompraFinalizada");
        }
      

        public ActionResult DestinoCompra()
        {
            return View();
        }

        public ActionResult RealizarPago()
        {
            return View();
        }

        public ActionResult CompraFinalizada()
        {
            return View();
        }

        public ActionResult Pagar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hola()
        {
            //var file = Request.Files[0];
            foreach (string item in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                string fileName = file.FileName;
                string UploadPath = "~/Images/";

                if (file.ContentLength == 0)
                    continue;
                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(HttpContext.Request.MapPath(UploadPath), fileName);
                    string extension = Path.GetExtension(file.FileName);

                    file.SaveAs(path);
                }
                return View();
            }
            return View();
        }

    }
}
