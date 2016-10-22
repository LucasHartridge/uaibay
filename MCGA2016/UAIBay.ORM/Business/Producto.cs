//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UAIBay.ORM.Business
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public Producto()
        {
            this.DetalleCompra = new HashSet<DetalleCompra>();
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
