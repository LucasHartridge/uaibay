using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class DetalleCompraViewModels
    {
        public int NroCompra { get; set; }
        public int CodProducto { get; set; }
        public string Cantidad { get; set; }

        public virtual CompraViewModels     Compra { get; set; }
        public virtual ProductoViewModels Producto { get; set; }
    }
}