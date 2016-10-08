using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class TarjetaCreditoViewModels
    {
        [Required]
        public int NroTarjeta { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        public int CodigoSeguro { get; set; }

        [Required]
        public string Titular { get; set; }
        public int UserId { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }

    }
}