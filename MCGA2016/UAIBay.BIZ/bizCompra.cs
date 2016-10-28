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
        public DateTime Fecha { get; set; }
        public string CUIT { get; set; }
        public double Total { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreateBy { get; set; }
        public Nullable<DateTime> ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual bizProveedor Proveedor { get; set; }
        public virtual ICollection<bizDetalleCompra> DetalleCompra { get; set; }
    }
}
