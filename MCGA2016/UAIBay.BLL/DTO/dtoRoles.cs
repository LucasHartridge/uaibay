using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
    public class dtoRoles
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<dtoUsuario> Usuario { get; set; }
    }
}
