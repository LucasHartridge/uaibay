using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
  public  class dtoDetalleVenta
    {
        public int NroVenta { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual dtoProducto Producto { get; set; }
        public virtual dtoVenta Venta { get; set; }
    }
}
