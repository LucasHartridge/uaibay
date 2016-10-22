using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.BIZ;
using UAIBay.Repository;

namespace UAIBay.BLL.DTO
{
    public class dtoProducto
    {
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }

        public virtual dtoCategoria Categoria { get; set; }
        public virtual ICollection<dtoDetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<dtoDetalleVenta> DetalleVenta { get; set; }

        public void Crear(dtoProducto producto)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoProducto, bizProducto>(producto);

            var repository = new ProductoRepository();
            repository.Insertar(BIZ);
            repository.Save();
        }




        public object TraerProductos()
        {
            var repository = new ProductoRepository();
            var BIZ = repository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoProducto>>(BIZ);

            return DTO;
        }
    }
}
