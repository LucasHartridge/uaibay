using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizCompra
    {
        public int NroCompra { get; set; }
        public System.DateTime Fecha { get; set; }
        public string CUIT { get; set; }
        public int Total { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime Changedon { get; set; }
        public int ChangedBy { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual bizProveedor Proveedor { get; set; }
        public virtual ICollection<bizDetalleCompra> DetalleCompra { get; set; }
    }
}
