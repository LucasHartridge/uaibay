using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class DetalleVentaViewModels
    {
        public int NroVenta { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual ProductoViewModels Producto { get; set; }
        public virtual VentaViewModels Venta { get; set; }
    }
}