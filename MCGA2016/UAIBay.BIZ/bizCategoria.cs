﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.BIZ
{
    public class bizCategoria
    {

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<bizProducto> Producto { get; set; }

    }
}
