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
        public DateTime Fecha { get; set; }
        public string NroComprobante { get; set; }
        public double Total { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<bizDetalleVenta> DetalleVenta { get; set; }
        //public virtual bizUsuario Usuario { get; set; }
    }
}
