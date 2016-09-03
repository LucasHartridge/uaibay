using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAIBay.WebSite.Models
{
    public class Producto
    {
    public int CodigoProducto { get; set; }
    public Categoria unaCategoria { get; set; }
    public string Descripcion { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ChangedOn { get; set; }
    public int ChangedBy { get; set; }
    public bool isDeleted { get; set; }
    }
}