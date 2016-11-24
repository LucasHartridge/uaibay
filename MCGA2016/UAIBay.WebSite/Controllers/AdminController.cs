using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAIBay.BLL.DTO;
using UAIBay.WebSite.ViewModel;
using UAIBay.WebSite.ViewModel.Reportes;

namespace UAIBay.WebSite.Controllers
{
    [Autorizaciones.AutorizarAdmin]
    public class AdminController : Controller
    {
        #region Index
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetChartProductosPocaCantidad()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);

            var productosFiltrados = (from q in productosVM
                                      orderby q.Cantidad ascending
                                      select q).Take(10);

            return Json(productosFiltrados.Select(p => new { p.Descripcion, p.Cantidad,p.PrecioCompra,p.PrecioVenta }), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Chart Compracion Precio Venta vs Precio Compra
        // GET: /ComparacionPrecioProducto/
        public ActionResult ComparacionPrecioProducto()
        {
            return View();
        }

        public JsonResult GetChartComparacionPrecioProducto()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);

            var productosFiltrados = (from q in productosVM
                            orderby q.PrecioVenta descending
                            select q).Take(10);

            return Json(productosFiltrados.Select(p => new { p.Descripcion, p.PrecioVenta, p.PrecioCompra }), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Chart Ventas Por Mes del Ultimo año
        public ActionResult VentasAnuales()
        {
            return View();
        }


        public JsonResult GetChartVentasMensuales()
        {
            var bll = new dtoVenta();
            var ventasbll = bll.TraerVentas();
            App_Start.AutoMapperWebConfiguration.Configure();
            var ventas = Mapper.Map<List<VentaViewModels>>(ventasbll);
            //OBTENGO LAS VENTAS DEL ULTIMO AÑO
            var ventasUltimoAño = from x in ventas
                                  where (x.Fecha <= DateTime.Now && x.Fecha >= DateTime.Now.AddYears(-1))
                                  select x;

            //MAPEO A ENTIDAD CONOCIDA
            List<dtoVenta> ventasDto = new List<dtoVenta>();
            foreach (var item in ventasUltimoAño)
            {
                dtoVenta unaVenta = new dtoVenta();
                unaVenta.Fecha = item.Fecha;
                unaVenta.Total = item.Total;
                ventasDto.Add(unaVenta);
            }

            //FILTRO X MES
            var list = VentasPorMesViewModels.ObtenerUltimos12Meses();
            var reporte = new List<VentasPorMesViewModels>();

            foreach (var mes in list)
            {

                var totalXMes = new VentasPorMesViewModels();
                totalXMes.Fecha = mes.Fecha;
                totalXMes.Cantidad = 0;
                totalXMes.Total = 0;
                
                foreach (var item in ventasDto)
                {
                    if (item.Fecha.Month == Convert.ToDateTime(mes.Fecha).Month && item.Fecha.Year == Convert.ToDateTime(mes.Fecha).Year)
                    {
                        totalXMes.Total += item.Total;
                        totalXMes.Cantidad += 1;
                    }
                }
                
                reporte.Add(totalXMes);
            }



            App_Start.AutoMapperWebConfiguration.Configure();

            var reporteFinal = VentasPorMesViewModels.ObtenerReporteFinal(reporte);
            return Json(reporte.Select(p => new { p.Cantidad, p.Fecha, p.Total }), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Productos Por Categoria
        // GET: /ProductosPorCategoria/
        public ActionResult ProductosPorCategoria()
        {
            return View();
        }

        public JsonResult GetChartProductosPorCategoria()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);

            var reporte = ViewModel.Reportes.ProductosPorCategoriaViewModels.ObtenerCantidadDeProductosPorCategoria(productosVM);

            return Json(reporte.Select(p => new { p.Categoria, p.Cantidad }), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Usuarios Por Provincia
        // GET: /ProductosPorCategoria/
        public ActionResult UsuariosPorProvincia()
        {
            return View();
        }

        public JsonResult GetChartUsuariosPorProvincia()
        {
            var bll = new dtoProducto();
            var productos = bll.TraerProductos();

            App_Start.AutoMapperWebConfiguration.Configure();

            var productosVM = Mapper.Map<List<ProductoViewModels>>(productos);

            var reporte = ViewModel.Reportes.ProductosPorCategoriaViewModels.ObtenerCantidadDeProductosPorCategoria(productosVM);

            return Json(reporte.Select(p => new { p.Categoria, p.Cantidad }), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}