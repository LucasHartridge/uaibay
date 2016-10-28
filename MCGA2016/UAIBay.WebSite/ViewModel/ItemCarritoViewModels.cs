using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAIBay.WebSite.ViewModel
{
    public class ItemCarritoViewModels
    {
        public int IdCarrito { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Precio { get; set; }

        public virtual CarritoViewModels Carrito { get; set; }
        public virtual ProductoViewModels Producto { get; set; }
    }
}