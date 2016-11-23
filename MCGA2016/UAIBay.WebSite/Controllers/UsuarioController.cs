using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UAIBay.WebSite.ViewModel;
using UAIBay.BLL.DTO;
using PagedList;
using System.Globalization;

namespace UAIBay.WebSite.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        //public ActionResult Index(int? page)
        //{
        //    var bllUsuario = new dtoUsuario();
        //    //var usuarios = bllUsuario.TraerUsuarios();
        //    App_Start.AutoMapperWebConfiguration.Configure();

        //    var usuariosViewmodel = Mapper.Map<List<UsuarioViewModels>>(usuarios);

        //    var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

        //    return View(usuariosViewmodel.ToPagedList(pageNumber, 9));
        //}
    }
}