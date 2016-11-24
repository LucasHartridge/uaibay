using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.WebSite.ViewModel;
using AutoMapper;
using UAIBay.BLL.DTO;
using PagedList;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace UAIBay.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Home/
        [Autorizaciones.AutorizarAdmin]
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
        [Autorizaciones.AutorizarAdmin]
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
        [Autorizaciones.AutorizarAdmin]
        public ActionResult Create(ProductoViewModels producto, HttpPostedFileBase file)
        {
            var bll = new dtoProducto();

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

            var id = Convert.ToInt32(Session["LogedUserID"]);

            var productoCreado = bll.Crear(DTO, id);

            GuardarImagen(file, productoCreado);


            return RedirectToAction("Index");
        }

        private void GuardarImagen(HttpPostedFileBase file, dtoProducto productoCreado)
        {

            foreach (var item in productoCreado.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string) && item.Name != "Imagen")
                {
                    string texto = item.GetValue(productoCreado, null).ToString();

                    item.SetValue(productoCreado, ConvertirMayuscula(texto));
                }
            }


            var bll = new dtoProducto();

            // Se carga la ruta física de la carpeta temp del sitio
            string ruta = Server.MapPath("~/ImgProductos");

            // Si el directorio no existe, crearlo
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);


            string archivo = String.Format("{0}\\{1}", ruta, productoCreado.CodProducto.ToString());

            // Se revisa el formato de la imagen
            string ext = Path.GetExtension(file.FileName).ToLower();

            string nombre = archivo + ext;

            file.SaveAs(nombre);
            productoCreado.Imagen = productoCreado.CodProducto.ToString() + ext;

            var id = Convert.ToInt32(Session["LogedUserID"]);

            bll.Actualizar(productoCreado, id);
        }



        [HttpGet]
        [Autorizaciones.AutorizarAdmin]
        public ActionResult Details(int id)
        {
            var bll = new dtoProducto();
            var producto = bll.BuscarUnProducto(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProducto, ProductoViewModels>(producto);
            return View(vmodel);
        }



        [HttpGet]
        [Autorizaciones.AutorizarAdmin]
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
        [Autorizaciones.AutorizarAdmin]
        public ActionResult Edit(ProductoViewModels producto, HttpPostedFileBase file)
        {

            App_Start.AutoMapperWebConfiguration.Configure();
            dtoProducto DTO = Mapper.Map<ProductoViewModels, dtoProducto>(producto);

            var bll = new dtoProducto();

            GuardarImagen(file, DTO);

            return RedirectToAction("Index");

        }



        [HttpGet]
        [Autorizaciones.AutorizarAdmin]
        public ActionResult Delete(int id)
        {
            var bll = new dtoProducto();
            var producto = bll.BuscarUnProducto(id);
            App_Start.AutoMapperWebConfiguration.Configure();
            var vmodel = Mapper.Map<dtoProducto, ProductoViewModels>(producto);
            return View(vmodel);
        }

        [HttpPost]
        [Autorizaciones.AutorizarAdmin]
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

        public ActionResult FiltrarPorCategoria(int? page, int idCategoria)
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            productosVM = productosVM.Where(x => x.IdCategoria == idCategoria).ToList();

            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);
            ViewBag.CategoriasSimple = categoriasViewmodel;

            ViewBag.ProductosAleatorios = productosVM.OrderBy(a => Guid.NewGuid()).Take(4).Where(x => x.IdCategoria == productosVM.FirstOrDefault().IdCategoria);
            ViewBag.PrimerProducto = productosVM.OrderBy(a => Guid.NewGuid()).Take(1).FirstOrDefault();

            var pageNumber = page ?? 1;
            return View(productosVM.ToPagedList(pageNumber, 9));
            //return View(productosVM);
        }

        public ActionResult BuscarProducto(string productoBuscar, int? page)
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

             App_Start.AutoMapperWebConfiguration.Configure();

             var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);
             ViewBag.CategoriasSimple = categoriasViewmodel;

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            string palabraBeta = productoBuscar;

            string palabra = palabraBeta.TrimEnd(' ');

            IEnumerable<ProductoViewModels> productosE;
            productosE = productosVM;

            if (!String.IsNullOrEmpty(palabra))
            {
                productosE = productosE.Where(p => p.Descripcion.ToUpper().Contains(palabra.ToUpper()) || p.Categoria.Nombre.ToUpper().Contains(palabra.ToUpper()));
            }

            productosE = productosE.ToList();

            ViewBag.ProductosAleatorios = productosVM.OrderBy(a => Guid.NewGuid()).Take(4).Where(x=> x.IdCategoria==productosE.FirstOrDefault().IdCategoria);
            ViewBag.PrimerProducto = productosVM.OrderBy(a => Guid.NewGuid()).Take(1).FirstOrDefault();

            var pageNumber = page ?? 1; 

            return View(productosE.ToPagedList(pageNumber, 9));
        }

        public static string ConvertirMayuscula(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

    }
}