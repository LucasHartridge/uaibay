using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoVenta
    {
        public int NroVenta { get; set; }
        public int UserId { get; set; }
        public DateTime Fecha { get; set; }
        public string CodPromocion { get; set; }
        public int Total { get; set; }

        public virtual ICollection<dtoDetalleVenta> DetalleVenta { get; set; }
        public virtual dtoPromocion Promocion { get; set; }
        public virtual dtoUsuario Usuario { get; set; }
    }
}
