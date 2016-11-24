using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;
using UAIBay.Servicios;
using PagedList;

namespace UAIBay.WebSite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            var provincias = LlenarComboProvincias();

            return View(provincias);
        }

        [HttpGet]
        public ActionResult UsuarioNoLogeado()
        {
            return View();
        }

        [HttpGet]
        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult MisCompras(int? page)
        {
            var bll = new dtoUsuario();

            int idUsuario = Convert.ToInt32(Session["LogedUserID"]);

            var ventas = bll.MisCompras(idUsuario);

            App_Start.AutoMapperWebConfiguration.Configure();

            List<VentaViewModels> ventasviewModel = Mapper.Map<List<VentaViewModels>>(ventas);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(ventasviewModel.ToPagedList(pageNumber, 9));

        }



        [HttpGet]
        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Details(int id, int? page)
        {
            var bll = new dtoVenta();
            var venta = bll.TraerVenta(id);
             App_Start.AutoMapperWebConfiguration.Configure();
            var ventaVM = Mapper.Map<dtoVenta, VentaViewModels>(venta);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            return View(ventaVM.DetalleVenta.ToPagedList(pageNumber, 9));
        }

        [HttpGet]
        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Cuenta()
        {
            var bll = new dtoUsuario();
            var usuario = bll.BuscarCuenta(Convert.ToInt32(Session["LogedUserID"]));

            App_Start.AutoMapperWebConfiguration.Configure();
            var usuarioVM = Mapper.Map<dtoUsuario, UsuarioViewModels>(usuario);

            return View(usuarioVM);

        }

        [HttpPost]
        [Autorizaciones.AutorizarUsuarioYAdmin]
        public ActionResult Cuenta(UsuarioViewModels usuario)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            dtoUsuario DTO = Mapper.Map<UsuarioViewModels, dtoUsuario>(usuario);

            var bll = new dtoUsuario();
            bll.Actualizar(DTO);

            return RedirectToAction("Cuenta");

        }

        public ActionResult Registrar(string nombre, string apellido, int dni, string password, string passwordRepetir,
            int telefono, string email, DateTime fechaNacimiento,
            bool sexo, string provincia, string localidad, string domicilio, int codigoPostal)
        {
            var bll = new dtoUsuario();
            if (password == passwordRepetir)
            {

                var existe = bll.BuscarUsuario(email);
                if (existe != null)
                {
                    ModelState.AddModelError("email", "*El e-mail ingresado corresponde a un usuario ya registrado.");

                    var provincias = LlenarComboProvincias();

                    return View("Login", provincias);
                }

                var dtoRol = new dtoRoles();
                var rolCliente = dtoRol.BuscarRolCliente();

                UsuarioViewModels usuarioVM = new UsuarioViewModels()
                {
                    Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre),
                    Apellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(apellido),
                    DNI = dni,
                    Password = password,
                    Telefono = telefono,
                    Email = email,
                    FechaNacimiento = fechaNacimiento,
                    Sexo = sexo
                };

                usuarioVM.Direccion = new List<DireccionViewModels>();

                DireccionViewModels direccionVM = new DireccionViewModels()
                {
                    CodigoPostal = codigoPostal.ToString(),
                    Domicilio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(domicilio),
                    Localidad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidad),
                    Provincia = provincia
                };

                usuarioVM.Direccion.Add(direccionVM);


                ViewBag.Password = password;

                //ENCRIPTAR PASSWORD
                var keyNew = EncriptadorPassword.GeneratePassword(5);
                var npassword = EncriptadorPassword.EncodePassword(password, keyNew);

                usuarioVM.Password = npassword;
                usuarioVM.PasswordHash = keyNew;

                App_Start.AutoMapperWebConfiguration.Configure();
                var DTO = Mapper.Map<UsuarioViewModels, dtoUsuario>(usuarioVM);

                DTO.Roles.Add(rolCliente);

                try
                {
                    UAIBay.Servicios.CorreoElectronico.Bienvenida(usuarioVM.Email, (usuarioVM.Nombre + " " + usuarioVM.Apellido));

                    bll.Crear(DTO);

                    return RedirectToAction("Ingresar", "Account", new { user = email, pw = ViewBag.Password });
                }
                catch (Exception)
                {

                    ModelState.AddModelError("email", "*El e-mail ingresado no es válido. ");

                    var provincias = LlenarComboProvincias();

                    return View("Login", provincias);

                }
                //}

            }


            return RedirectToAction("Index");
        }


        public ActionResult Ingresar(string user, string pw)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var bll = new dtoUsuario();
                    var usuario = new dtoUsuario();


                    try
                    {

                        usuario = bll.BuscarUsuario(user);

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("login", "*Usuario o contraseña incorrecto. Vuelva a intentar.");

                        var provincias = LlenarComboProvincias();

                        return View("Login", provincias);

                    }


                    if (usuario != null)
                    {


                        var hashCode = usuario.PasswordHash;

                        //Password Hasing Process Call Helper Class Method    
                        var encodingPassword = EncriptadorPassword.EncodePassword(pw, hashCode);
                        //Check Login Detail User Name Or Password    

                        if (usuario.Password.Equals(encodingPassword))
                        {
                            Session["LogedUserID"] = usuario.UserId.ToString();
                            Session["LogedUserNombre"] = usuario.Nombre;
                            Session["LogedUserEmail"] = usuario.Email;
                            Session["LogedUserRol"] = usuario.Roles.FirstOrDefault().Nombre;
                            return RedirectToAction("AfterLogin");

                        }
                        else
                        {
                            ModelState.AddModelError("login", "*Usuario o contraseña incorrecto. Vuelva a intentar.");

                            var provincias = LlenarComboProvincias();

                            return View("Login", provincias);
                        }
                    }

                }

                ModelState.AddModelError("login", "*Usuario o contraseña incorrecto. Vuelva a intentar.");

                var provinciasS = LlenarComboProvincias();

                return View("Login",provinciasS);

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AfterLogin()
        {

            var rol = Session["LogedUserRol"].ToString();
            var id = Session["LogedUserID"].ToString();

            if (Session["LogedUserRol"].ToString() == "Cliente" && Session["LogedUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }


        public ActionResult Logout()
        {
            Session["LogedUserID"] = null;
            Session["LogedUserNombre"] = null;
            Session["LogedUserEmail"] = null;
            Session["LogedUserRol"] = null;

            return RedirectToAction("Index", "Home");
        }


        public List<SelectListItem> LlenarComboProvincias()
        {
            var provincias = ProvinciasFill.CargarProvincias();

            List<SelectListItem> Provincia = provincias.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.ToString(),
                    Value = a.ToString(),
                    Selected = false
                };
            });

            return Provincia;
        }


    }
}