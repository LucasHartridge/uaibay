using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizDireccion
    {
        public int IDDireccion { get; set; }
        public int UserId { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual bizUsuario Usuario { get; set; }
    }
}
