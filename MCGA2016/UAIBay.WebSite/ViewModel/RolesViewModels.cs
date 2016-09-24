using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class RolesViewModels
    {
        public RolesViewModels()
        {
            this.Usuario = new HashSet<UsuarioViewModels>();
        }
    
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<UsuarioViewModels> Usuario { get; set; }
    }
}