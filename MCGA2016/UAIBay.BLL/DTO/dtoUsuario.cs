using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
   public class dtoUsuario
    {
        public int UserId { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public bool Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }

        //public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        //public virtual ICollection<DataLog> DataLog { get; set; }
        //public virtual ICollection<Direccion> Direccion { get; set; }
        //public virtual ICollection<ErrorLog> ErrorLog { get; set; }
        //public virtual ICollection<History> History { get; set; }
        //public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
        //public virtual ICollection<Venta> Venta { get; set; }
        //public virtual ICollection<Roles> Roles { get; set; }
    }
}
