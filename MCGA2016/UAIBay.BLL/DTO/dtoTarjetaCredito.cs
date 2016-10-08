﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BLL.DTO
{
   public class dtoTarjetaCredito
    {
        public int NroTarjeta { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int CodigoSeguro { get; set; }
        public string Titular { get; set; }
        public int UserId { get; set; }

        public virtual dtoUsuario Usuario { get; set; }
    }
}
