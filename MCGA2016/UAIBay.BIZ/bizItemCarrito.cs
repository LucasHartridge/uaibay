using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizItemCarrito
    {
        public int IdCarrito { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Precio { get; set; }

        //public virtual bizCarrito Carrito { get; set; }
        public virtual bizProducto Producto { get; set; }
    }
}
