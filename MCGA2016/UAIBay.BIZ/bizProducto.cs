using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizProducto
    {
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
        public Nullable<DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual bizCategoria Categoria { get; set; }
        public virtual ICollection<bizDetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<bizDetalleVenta> DetalleVenta { get; set; }


        //public bizProducto()
        //{
        //    this.ChangedBy = null;
        //    this.ChangedOn = null;
        //    this.DeletedOn = null;
        //}

    }
}
