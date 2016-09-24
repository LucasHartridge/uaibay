using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class ProductoViewModels
    {
        public ProductoViewModels()
        {
            this.DetalleCompra = new HashSet<DetalleCompraViewModels>();
            this.DetalleVenta = new HashSet<DetalleVentaViewModels>();
        }
    
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual CategoriaViewModels Categoria { get; set; }
        public virtual ICollection<DetalleCompraViewModels> DetalleCompra { get; set; }
        public virtual ICollection<DetalleVentaViewModels> DetalleVenta { get; set; }
    }
}