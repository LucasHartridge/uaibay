using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class CategoriaViewModels
    {
        public CategoriaViewModels()
        {
            this.Producto = new HashSet<ProductoViewModels>();
        }
    
        public int IdCategoria { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<ProductoViewModels> Producto { get; set; }

    }
}