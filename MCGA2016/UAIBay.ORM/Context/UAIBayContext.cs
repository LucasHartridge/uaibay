using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;

namespace UAIBay.ORM.Context
{
    public class UAIBayContext:DbContext
    {
        public UAIBayContext() : base("name=UAIBayAccess")
        {

        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<ItemCarrito> ItemCarrito { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Promocion> Promociones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
    }
}
