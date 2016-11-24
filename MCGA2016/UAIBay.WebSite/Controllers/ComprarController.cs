using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;
using System.IO;
using UAIBay.Servicios;
using PagedList;

namespace UAIBay.WebSite.Controllers
{

    public class ComprarController : Controller
    {

        private Servicios.Encriptador Encriptador = new Encriptador();
        //
        // GET: /Comprar/
        public ActionResult Catalogo(int? page)
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
            var categoriasDTO = bllcat.TraerCategorias();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);
            var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

            ViewBag.CategoriasSimple = categoriasViewmodel;
            ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();

            ViewBag.ProductosAleatorios = productosVM.OrderBy(a => Guid.NewGuid()).Take(4);
            ViewBag.PrimerProducto = productosVM.OrderBy(a => Guid.NewGuid()).Take(1).FirstOrDefault();

            var pageNumber = page ?? 1;
            return View(productosVM.ToPagedList(pageNumber, 9));
        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Carrito()
        {
            if (Session["LogedUserID"] != null)
            {
                int userId = Convert.ToInt32(Session["LogedUserID"]);

                var bll = new dtoCarrito();
                var carrito = bll.TraerCarrito(userId);

                var bllUsuario = new dtoUsuario();
                var usuario = bllUsuario.BuscarCuenta(userId);

                if (carrito == null)
                {

                    bll.CrearCarrito(new dtoCarrito() { UserId = userId, IdCarrito = userId });
                    carrito = bll.TraerCarrito(userId);
                }

                var bllcat = new UAIBay.BLL.DTO.dtoCategoria();
                var categoriasDTO = bllcat.TraerCategorias();

                App_Start.AutoMapperWebConfiguration.Configure();

                var carritoVM = Mapper.Map<dtoCarrito, CarritoViewModels>(carrito);
                var categoriasViewmodel = Mapper.Map<List<CategoriaViewModels>>(categoriasDTO);

                ViewBag.Categorias = categoriasViewmodel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.IdCategoria.ToString() }).ToList();
                ViewBag.Carrito = carrito.IdCarrito;
                ViewBag.Direcciones = usuario.Direccion.Select(x => new SelectListItem { Text = x.Domicilio + " - " + x.Localidad + " - CP: " + x.CodigoPostal + " - " + x.Provincia, Value = x.IDDireccion.ToString() }).ToList();

                var provincias = ProvinciasFill.CargarProvincias();

                ViewBag.Provincia = provincias.Select(x => new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = x.ToString()
                });

                return View("Carrito", carritoVM.ItemCarrito);
            }
            else
            {
                return RedirectToAction("UsuarioNoLogeado", "Account");

            }


        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult AgregarItem(int codProducto)
        {
            if (Session["LogedUserID"] != null)
            {

                try
                {
                    int idCarrito = Convert.ToInt32(Session["LogedUserID"]);

                    var bll = new dtoCarrito();

                    bll.AgregarProducto(codProducto, idCarrito);

                    return RedirectToAction("Carrito", new { userId = idCarrito });
                }
                catch (Exception)
                {
                    return RedirectToAction("CantidadSuperada");
                }
            }
            else
            {
                return RedirectToAction("UsuarioNoLogeado", "Account");
            }



        }


        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult AgregarItemPopUp(int codProducto, int cantidad)
        {
            if (Session["LogedUserID"] != null)
            {
                try
                {
                    int idCarrito = Convert.ToInt32(Session["LogedUserID"]);

                    var bll = new dtoCarrito();

                    bll.AgregarProducto(codProducto, idCarrito, cantidad);

                    return RedirectToAction("Carrito", new { userId = idCarrito });
                }
                catch (Exception)
                {
                    return RedirectToAction("CantidadSuperada");
                }
            }
            else
            {
                return RedirectToAction("UsuarioNoLogeado", "Account");
            }


        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult QuitarItem(int codProducto)
        {

            int nroCarrito = Convert.ToInt32(Session["LogedUserID"]);

            var bll = new dtoCarrito();

            bll.QuitarProducto(codProducto, nroCarrito);

            return RedirectToAction("Carrito", new { userId = nroCarrito });
        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult CantidadSuperada()
        {
            return View();
        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Pagar(double totalcarrito, List<ItemCarritoViewModels> model, string descuento, string codigoCorrecto, string cod, string totCod)
        {
            var bll = new dtoCarrito();

            int idCarrito = Convert.ToInt32(Session["LogedUserID"]);

            App_Start.AutoMapperWebConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoItemCarrito>>(model);

            bll.ActualizarCarrito(DTO, idCarrito);

            bool codigoCorrectoDEncriptado = true;

            if (string.IsNullOrEmpty(codigoCorrecto) == false)
            {
                codigoCorrectoDEncriptado = Convert.ToBoolean(Encriptador.Desencriptar(codigoCorrecto));
            }


            if (descuento != null && codigoCorrectoDEncriptado == true)
            {
                double totalDEncriptado = Convert.ToDouble(Encriptador.Desencriptar(totCod));
                int descuentoDEncriptado = Convert.ToInt32(Encriptador.Desencriptar(descuento));
                string codDEncriptado = Encriptador.Desencriptar(cod);

                double porcentaje = Convert.ToDouble(descuentoDEncriptado) / (double)100;
                double descuentoAplicado = porcentaje * totalDEncriptado;
                double nuevoTotal = totalDEncriptado - descuentoAplicado;
                ViewBag.CodigoUtilizado = codDEncriptado;
                return View(nuevoTotal);
            }
            else if (codigoCorrectoDEncriptado == false)
            {
                double total = totalcarrito;
                ModelState.AddModelError("codigoDes", "*El código ingresado no es válido.");
                return View(total);
            }
            else
            {
                double total = totalcarrito;
                return View(total);
            }
        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Comprar(double total, string codigoDes, string codigoD = null)
        {
            var bll = new dtoCarrito();
            var bllCodigo = new dtoPromocion();

            int nroCarrito = Convert.ToInt32(Session["LogedUserID"]);

            // COMPROBAR CODIGO DE DESCUENTO

            if (codigoDes != "")
            {
                string codigo = codigoDes.ToString();

                var promociones = bllCodigo.TraerPromociones().Where(x => x.FechaVencimiento >= DateTime.Now).ToList();

                var existe = promociones.Where(x => x.Nro == codigo).FirstOrDefault();

                if (existe != null)
                {

                    var totalEncriptado = Encriptador.Encriptar(total.ToString());
                    var descuentoEncriptado = Encriptador.Encriptar(existe.Descuento.ToString());
                    var codigoCorrectoEncriptado = Encriptador.Encriptar("true");
                    var codEncriptado = Encriptador.Encriptar(existe.Nro);

                    return RedirectToAction("Pagar", new { totalcarrito = 0, descuento = descuentoEncriptado, codigoCorrecto = codigoCorrectoEncriptado, cod = codEncriptado, totCod = totalEncriptado });
                }
                else
                {
                    var codigoCorrectoEncriptado = Encriptador.Encriptar("false");

                    return RedirectToAction("Pagar", new { totalcarrito = total, codigoCorrecto = codigoCorrectoEncriptado });
                }
            }


            bll.RealizarCompra(nroCarrito, codigoD);

            return RedirectToAction("CompraFinalizada");
        }

        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult CompraFinalizada()
        {
            return View();
        }










    }
}
