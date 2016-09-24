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

        public virtual ICollection<DetalleVentaViewModels> DetalleVenta { get; set; }
        public virtual PromocionViewModels Promocion { get; set; }
        public virtual UsuarioViewModels Usuario { get; set; }


    }
}