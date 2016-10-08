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

        [Required]
        public string Domicilio { get; set; }

        [Required]
        public string Localidad { get; set; }

        [Required]
        public string Provincia { get; set; }

        [Required]
        public string CodigoPostal { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }

    }
}