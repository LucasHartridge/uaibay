using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAIBay.WebSite.Models
{
    public class Correo
    {
        public int IdMail { get; set; }
        public Producto unProducto { get; set; }
        public string Asunto { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto  { get; set; }
    }
}