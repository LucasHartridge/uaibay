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
            return View();
        }


        [HttpGet]
        public ActionResult Cuenta()
        {
            var bll = new dtoUsuario();
            var usuario = bll.BuscarCuenta(Convert.ToInt32(Session["LogedUserID"]));

            App_Start.AutoMapperWebConfiguration.Configure();
            var usuarioVM = Mapper.Map<dtoUsuario, UsuarioViewModels>(usuario);

            return View(usuarioVM);

        }

        [HttpPost]
        public ActionResult Cuenta(UsuarioViewModels usuario)
        {
            App_Start.AutoMapperWebConfiguration.Configure();
            dtoUsuario DTO = Mapper.Map<UsuarioViewModels, dtoUsuario>(usuario);

            var bll = new dtoUsuario();
            bll.Actualizar(DTO);

            return RedirectToAction("Cuenta");

        }

        public ActionResult Registrar(string nombre, string apellido, int dni, string password, string passwordRepetir, int telefono, string email, DateTime fechaNacimiento, bool sexo)
        {
            var bll = new dtoUsuario();
            if (password == passwordRepetir)
            {
                //try
                //{

                var existe = bll.BuscarUsuario(email);
                if (existe != null)
                {
                    ModelState.AddModelError("email", "*El e-mail ingresado corresponde a un usuario ya registrado.");

                    return View();
                }

                //}
                //catch (Exception)
                //{
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

                    return View();

                }
                //}

            }


            return RedirectToAction("Index");
        }


        public ActionResult Ingresar(string user, string pw)
        {
            try
            {

                if (user == "")
                {
                    ModelState.AddModelError("user", "El campo usuario no puede estar vacio");
                }

                if (pw == "")
                {
                    ModelState.AddModelError("pw", "El campo password no puede estar vacio");
                }


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

                        return View("Login");

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

                            return View("Login");
                        }
                    }

                }

                return View("Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserRol"] == "Cliente" || Session["LogedUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (true)
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






    }
}