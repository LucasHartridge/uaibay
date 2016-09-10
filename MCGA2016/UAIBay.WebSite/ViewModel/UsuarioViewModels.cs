using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class UsuarioViewModels
    {
        public UsuarioViewModels()
        {
            this.ActivityLog = new HashSet<ActivityLogViewModels>();
            this.DataLog = new HashSet<DataLogViewModels>();
            this.Direccion = new HashSet<DireccionViewModels>();
            this.ErrorLog = new HashSet<ErrorLogViewModels>();
            this.History = new HashSet<HistoryViewModels>();
            this.TarjetaCredito = new HashSet<TarjetaCreditoViewModels>();
            this.Venta = new HashSet<VentaViewModels>();
            this.Roles = new HashSet<RolesViewModels>();
        }
    
        public int UserId { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public bool Sexo { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public System.DateTime DeleteOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ActivityLogViewModels> ActivityLog { get; set; }
        public virtual ICollection<DataLogViewModels> DataLog { get; set; }
        public virtual ICollection<DireccionViewModels> Direccion { get; set; }
        public virtual ICollection<ErrorLogViewModels> ErrorLog { get; set; }
        public virtual ICollection<HistoryViewModels> History { get; set; }
        public virtual ICollection<TarjetaCreditoViewModels> TarjetaCredito { get; set; }
        public virtual ICollection<VentaViewModels> Venta { get; set; }
        public virtual ICollection<RolesViewModels> Roles { get; set; }
    }
}