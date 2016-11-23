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

        public dtoCarrito()
        {
            this.ItemCarrito = new HashSet<dtoItemCarrito>();
        }

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

            if (BIZ != null)
            {
                BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
                var DTO = Mapper.Map<bizCarrito, dtoCarrito>(BIZ);

                return DTO;
            }

            return null;
        }


        public void AgregarProducto(int codProducto, int codCarrito, int cant = 1)
        {
            try
            {
                var carrito = TraerCarrito(codCarrito);

                var bllPrd = new dtoProducto();
                var producto = bllPrd.BuscarUnProducto(codProducto);


                if (carrito == null)
                {
                    CrearCarrito(new dtoCarrito() { UserId = codCarrito, IdCarrito = codCarrito });
                    carrito = TraerCarrito(codCarrito);
                }

                var consultarProducto = carrito.ItemCarrito.Where(x => x.CodProducto == codProducto).FirstOrDefault();

                var repo = new CarritoRepository();

                if (consultarProducto != null)
                {
                    consultarProducto.Cantidad += cant;

                    if (consultarProducto.Cantidad < 10)
                    {
                        consultarProducto.Subtotal = consultarProducto.Cantidad * consultarProducto.Precio;

                        BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
                        var BIZ = Mapper.Map<dtoItemCarrito, bizItemCarrito>(consultarProducto);

                        repo.ActualizarProducto(BIZ);
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                else
                {
                    var item = new dtoItemCarrito();
                    item.CodProducto = codProducto;
                    item.Cantidad = cant;
                    item.Subtotal = (item.Cantidad * producto.PrecioVenta);
                    item.Precio = producto.PrecioVenta;
                    item.IdCarrito = carrito.IdCarrito;

                    BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
                    var BIZ = Mapper.Map<dtoItemCarrito, bizItemCarrito>(item);

                    repo.AgregarProducto(BIZ);

                }



                repo.Save();
            }
            catch (Exception)
            {

                throw;
            }



        }


        public void QuitarProducto(int codProducto, int nroCarrito)
        {
            var repo = new CarritoRepository();
            repo.QuitarProducto(codProducto, nroCarrito);
            repo.Save();
        }

        public void RealizarCompra(int nroCarrito, string codigoDescuento = null)
        {
            var carrito = TraerCarrito(nroCarrito);

            var bllVenta = new dtoVenta();
            bllVenta.RealizarCompra(carrito, codigoDescuento);
        }


        public void ActualizarCarrito(List<dtoItemCarrito> Items, int nroCarrito)
        {
            var repo = new CarritoRepository();

            repo.QuitarTodosLosProductos(nroCarrito);
            repo.Save();

            foreach (var p in Items)
            {
                var bll = new dtoProducto();
                var producto = bll.BuscarUnProducto(p.CodProducto);

                var item = new dtoItemCarrito();
                item.CodProducto = p.CodProducto;
                item.Cantidad = p.Cantidad;
                item.Subtotal = (p.Cantidad * p.Precio);
                item.Precio = p.Precio;
                item.IdCarrito = nroCarrito;

                BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
                var BIZ = Mapper.Map<dtoItemCarrito, bizItemCarrito>(item);

                repo.AgregarProducto(BIZ);
                repo.Save();
            }


        }
    }
}
