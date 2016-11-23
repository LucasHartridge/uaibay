using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizDetalleVenta
    {
        public int NroVenta { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual bizProducto Producto { get; set; }
        //public virtual bizVenta Venta { get; set; }
    }
}
