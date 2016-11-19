using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.Repository;
using AutoMapper;
using UAIBay.BIZ;

namespace UAIBay.BLL.DTO
{
    public class dtoCarrito
    {
        public int IdCarrito { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<DateTime> LastUpdate { get; set; }

        public virtual ICollection<dtoItemCarrito> ItemCarrito { get; set; }

        public void CrearCarrito(dtoCarrito carrito)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoCarrito, bizCarrito>(carrito);

            BIZ.CreatedOn = DateTime.Now;

            var repo = new CarritoRepository();
            repo.CrearCarrito(BIZ);
            repo.Save();
        }


        public dtoCarrito TraerCarrito(int userId)
        {
            var repo = new CarritoRepository();
            var BIZ = repo.TraerPorId(userId);

            if (BIZ!=null)
            {
                BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
                var DTO = Mapper.Map<bizCarrito, dtoCarrito>(BIZ);

                return DTO;
            }

            return null;
        }


        public void AgregarProducto(int codProducto, int codCarrito)
        {

            var carrito = TraerCarrito(codCarrito);

            var bllPrd= new dtoProducto();
            var producto=bllPrd.BuscarUnProducto(codProducto);
            

            if (carrito==null)
            {
                CrearCarrito(new dtoCarrito() { UserId = codCarrito, IdCarrito = codCarrito });
                carrito = TraerCarrito(codCarrito);
            }

            var item = new dtoItemCarrito();
            item.CodProducto = codProducto;
            item.Cantidad = 1;
            item.Subtotal = (item.Cantidad * producto.PrecioVenta);
            item.Precio = producto.PrecioVenta;
            item.IdCarrito = carrito.IdCarrito;

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoItemCarrito, bizItemCarrito>(item);

            var repo = new CarritoRepository();
            repo.AgregarProducto(BIZ);
            repo.Save();
        }


        public void QuitarProducto(int codProducto, int nroCarrito)
        {
            var repo = new CarritoRepository();
            repo.QuitarProducto(codProducto,nroCarrito);
            repo.Save();
        }

        public void RealizarCompra(int nroCarrito)
        {
            var carrito = TraerCarrito(nroCarrito);

            var bllVenta = new dtoVenta();
            bllVenta.RealizarCompra(carrito);
        }

    }
}
