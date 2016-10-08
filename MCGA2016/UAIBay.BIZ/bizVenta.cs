using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizVenta
    {
        public int NroVenta { get; set; }
        public int UserId { get; set; }
        public System.DateTime Fecha { get; set; }
        public string CodPromocion { get; set; }
        public int Total { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<bizDetalleVenta> DetalleVenta { get; set; }
        public virtual bizPromocion Promocion { get; set; }
        public virtual bizUsuario Usuario { get; set; }
    }
}
