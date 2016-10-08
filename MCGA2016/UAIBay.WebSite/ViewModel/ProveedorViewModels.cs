using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class ProveedorViewModels
    {
        public ProveedorViewModels()
        {
            this.Compra = new HashSet<CompraViewModels>();
        }

        [Required]
        public string CUIT { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Domicilio { get; set; }

        [Required]
        public string Localidad { get; set; }

        [Required]
        public string CodigoPostal { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Telefono { get; set; }


        public virtual ICollection<CompraViewModels> Compra { get; set; }
    }
}