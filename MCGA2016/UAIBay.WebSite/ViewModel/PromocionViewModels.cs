using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class PromocionViewModels
    {
        public PromocionViewModels()
        {
            this.Venta = new HashSet<VentaViewModels>();
        }
    
        public string CodPromocion { get; set; }
        public int Descuento { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
    
        public virtual ICollection<VentaViewModels> Venta { get; set; }
    }
}