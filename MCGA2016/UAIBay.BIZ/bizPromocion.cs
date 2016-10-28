using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizPromocion
    {
        public string CodPromocion { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual ICollection<bizVenta> Venta { get; set; }
    }
}
