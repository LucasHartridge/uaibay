using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoItemCarrito
    {
        public int IdCarrito { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Precio { get; set; }

        //public virtual dtoCarrito Carrito { get; set; }
        public virtual dtoProducto Producto { get; set; }

    }
}
