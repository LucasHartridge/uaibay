using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoDetalleCompra
    {
        public int NroCompra { get; set; }
        public int CodProducto { get; set; }
        public string Cantidad { get; set; }

        public virtual dtoCompra Compra { get; set; }
        public virtual dtoProducto Producto { get; set; }
    }
}
