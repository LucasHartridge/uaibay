using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
   public class bizUsuario
    {
        public int UserId { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public bool Sexo { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public Nullable<bool> EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public Nullable<int> AccessFailedCount { get; set; }
        public Nullable<System.DateTime> DeleteOn { get; set; }
        public bool IsDeleted { get; set; }
        public int IdRol { get; set; }

        //public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        //public virtual ICollection<DataLog> DataLog { get; set; }
        public virtual ICollection<bizDireccion> Direccion { get; set; }
        //public virtual ICollection<ErrorLog> ErrorLog { get; set; }
        //public virtual ICollection<History> History { get; set; }
        //public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
        //public virtual ICollection<Venta> Venta { get; set; }
        public virtual bizRoles Roles { get; set; }
    }
}
