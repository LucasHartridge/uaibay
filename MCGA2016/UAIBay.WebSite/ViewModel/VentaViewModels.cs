using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class VentaViewModels
    {

        public VentaViewModels()
        {
            this.DetalleVenta = new HashSet<DetalleVentaViewModels>();
        }


        [Display(Name = "Nro de venta")]
        public int NroVenta { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Fecha de compra")]
        public DateTime Fecha { get; set; }
        public string CodPromocion { get; set; }
        public double Total { get; set; }

        public virtual ICollection<DetalleVentaViewModels> DetalleVenta { get; set; }
        public virtual PromocionViewModels Promocion { get; set; }
        public virtual UsuarioViewModels Usuario { get; set; }


    }
}