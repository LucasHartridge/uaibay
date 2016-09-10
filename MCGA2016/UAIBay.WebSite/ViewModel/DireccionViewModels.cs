using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class DireccionViewModels
    {

        public int IDDireccion { get; set; }
        public int UserId { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }

    }
}