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
        public DateTime Fecha { get; set; }
        public string CUIT { get; set; }
        public double Total { get; set; }
    
        public virtual ProveedorViewModels Proveedor { get; set; }
        public virtual ICollection<DetalleCompraViewModels> DetalleCompra { get; set; }
    }
}