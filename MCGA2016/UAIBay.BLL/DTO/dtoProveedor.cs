using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoProveedor
    {
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public virtual ICollection<dtoCompra> Compra { get; set; }
    }
}
