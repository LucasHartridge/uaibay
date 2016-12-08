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
        //[RequireHttps]
        public ActionResult Index()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            //var productosTopDiez = productosVM.Take(9).ToList();

            var productosTopDiez = productosVM.OrderBy(a => Guid.NewGuid()).Take(9).ToList();

            foreach (var item in productosTopDiez)
            {
                if (item.Descripcion.Length > 35)
                {

                    var texto = item.Descripcion.Substring(0, 35);

                    item.Descripcion = texto;

                }
            }

            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);
            ViewBag.Categorias = categoriasViewmodel;

            ViewBag.ProductosAleatorios = productosVM.OrderBy(a => Guid.NewGuid()).Take(4);
            ViewBag.PrimerProducto = productosVM.OrderBy(a => Guid.NewGuid()).Take(1).FirstOrDefault();

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

        [HttpPost]
        public ActionResult Email(String txtemail, String txtnombre, String txtapellido, String txtmensaje)
        {
            UAIBay.Servicios.CorreoElectronico.EnviarCorreo(txtemail, txtnombre + txtapellido, txtmensaje, "CONSULTA PRODUCTO");

            return View("EmailEnviado");
        }

        [HttpPost]
        public ActionResult EmailContacto(String txtemail, String txtnombre, String txtSubject, String txtmensaje)
        {
            UAIBay.Servicios.CorreoElectronico.EnviarCorreo(txtemail, txtnombre, txtmensaje, txtSubject);

            return View("EmailEnviado");
        }
    }
}



