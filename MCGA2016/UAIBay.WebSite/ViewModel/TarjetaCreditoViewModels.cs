using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class TarjetaCreditoViewModels
    {

        public int NroTarjeta { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public int CodigoSeguro { get; set; }
        public string Titular { get; set; }
        public int UserId { get; set; }

        public virtual UsuarioViewModels Usuario { get; set; }

    }
}