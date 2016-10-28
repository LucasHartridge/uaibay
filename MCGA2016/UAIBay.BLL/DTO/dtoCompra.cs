using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
  public  class dtoCompra
    {
        public int NroCompra { get; set; }
        public DateTime Fecha { get; set; }
        public string CUIT { get; set; }
        public double Total { get; set; }

        public virtual dtoProveedor Proveedor { get; set; }
        public virtual ICollection<dtoDetalleCompra> DetalleCompra { get; set; }

    }
}
