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
    
    public partial class Compra
    {
        public Compra()
        {
            this.DetalleCompra = new HashSet<DetalleCompra>();
        }
    
        public int NroCompra { get; set; }
        public System.DateTime Fecha { get; set; }
        public string CUIT { get; set; }
        public int Total { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreateBy { get; set; }
        public Nullable<System.DateTime> Changedon { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}
