using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UAIBay.WebSite.ViewModel
{
    public class PromocionViewModels
    {

        public int CodPromocion { get; set; }

        [Required]
        public string Nro { get; set; }

        [Required]
        public int Descuento { get; set; }

        [Required]
        [Display(Name="Fecha de vencimiento")]
        public DateTime FechaVencimiento { get; set; }

 
    }
}