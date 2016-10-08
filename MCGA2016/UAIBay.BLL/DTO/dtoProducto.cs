using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoProducto
    {
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }

        public virtual dtoCategoria Categoria { get; set; }
        public virtual ICollection<dtoDetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<dtoDetalleVenta> DetalleVenta { get; set; }
    }
}
