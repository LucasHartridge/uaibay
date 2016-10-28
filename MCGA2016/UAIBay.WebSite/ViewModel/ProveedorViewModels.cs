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
        [StringLength(5)]
        [Display(Name = "Código postal")]
        public string CodigoPostal { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress,ErrorMessage="El formato de e-mail ingresado no es válido.")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Teléfono")]
        public int Telefono { get; set; }


        public virtual ICollection<CompraViewModels> Compra { get; set; }
    }
}