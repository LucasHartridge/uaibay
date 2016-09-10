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
    
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        public System.DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<CompraViewModels> Compra { get; set; }
    }
}