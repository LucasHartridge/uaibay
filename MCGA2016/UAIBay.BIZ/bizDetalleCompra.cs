using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizDetalleCompra
    {

        public int NroCompra { get; set; }
        public int CodProducto { get; set; }
        public string Cantidad { get; set; }

        public virtual bizCompra Compra { get; set; }
        public virtual bizProducto Producto { get; set; }

    }
}
