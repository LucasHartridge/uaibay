using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
   public class dtoPromocion
    {
        public string CodPromocion { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual ICollection<dtoVenta> Venta { get; set; }
    }
}
