using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.Models
{
    public class EmailViewModel
    {
        [Required,Display(Name="Nombre")]
        public string FromName { get; set; }
        [Required,Display(Name="Cuenta de correo")]
        public string FromEmail { get; set; }
        [Required,Display(Name="Mensaje")]
        public string Message { get; set; }
        public Guid? Producto { get; set; }
    }
}