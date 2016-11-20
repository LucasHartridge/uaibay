using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UAIBay.BIZ;
using UAIBay.Repository;

namespace UAIBay.BLL.DTO
{
    public class dtoVenta
    {
        public int NroVenta { get; set; }
        public int UserId { get; set; }
        public DateTime Fecha { get; set; }
        public string NroComprobante { get; set; }
        public double Total { get; set; }

        public virtual ICollection<dtoDetalleVenta> DetalleVenta { get; set; }
        public virtual dtoUsuario Usuario { get; set; }

        public List<DTO.dtoVenta> TraerVentas()
        {
            var repository = new VentaRepository();
            var BIZ = repository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoVenta>>(BIZ);

            return DTO;
        }
        public void RealizarCompra(dtoCarrito carrito, string codDescuento = null)
        {

            var repo = new VentaRepository();
            var nuevaVenta = new dtoVenta();
            nuevaVenta.DetalleVenta = new List<dtoDetalleVenta>();

            nuevaVenta.UserId = carrito.UserId;
            nuevaVenta.Fecha = DateTime.Now;
            nuevaVenta.NroComprobante = codDescuento;
            nuevaVenta.Total = TraerTotal(carrito.ItemCarrito);


            foreach (var item in carrito.ItemCarrito)
            {
                var nuevoDetalle = new dtoDetalleVenta();
                nuevoDetalle.NroVenta = 0;
                nuevoDetalle.CodProducto = item.CodProducto;
                nuevoDetalle.Cantidad = item.Cantidad;

                nuevaVenta.DetalleVenta.Add(nuevoDetalle);
            }

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = AutoMapper.Mapper.Map<dtoVenta, bizVenta>(nuevaVenta);

            repo.Insertar(BIZ);

        }

        private double TraerTotal(ICollection<dtoItemCarrito> listaItem)
        {
            double total = 0;

            foreach (var item in listaItem)
            {
                total += item.Subtotal;
            }

            return total;
        }


    }
}
