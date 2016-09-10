using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class CompraViewModels
    {
        public CompraViewModels()
        {
            this.DetalleCompra = new HashSet<DetalleCompraViewModels>();
        }
    
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
    
        public virtual ProveedorViewModels Proveedor { get; set; }
        public virtual ICollection<DetalleCompraViewModels> DetalleCompra { get; set; }
    }
}