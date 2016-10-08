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

        [Required]
        public int Descuento { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public virtual ICollection<VentaViewModels> Venta { get; set; }
    }
}