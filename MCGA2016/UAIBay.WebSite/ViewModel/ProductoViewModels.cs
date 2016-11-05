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

        [Required]
        [Display(Name = "Nombre de producto")]
        public string Descripcion { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio de compra")]
        public double PrecioCompra { get; set; }

        [Required]
        [Display(Name = "Precio de venta")]
        public double PrecioVenta { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        [Required]
        public string Imagen { get; set; }



        public virtual CategoriaViewModels Categoria { get; set; }
        public virtual ICollection<DetalleCompraViewModels> DetalleCompra { get; set; }
        public virtual ICollection<DetalleVentaViewModels> DetalleVenta { get; set; }
        public virtual ICollection<ItemCarritoViewModels> ItemCarrito { get; set; }
    }
}