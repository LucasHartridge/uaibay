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
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }

        public virtual dtoCategoria Categoria { get; set; }
        public virtual ICollection<dtoDetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<dtoDetalleVenta> DetalleVenta { get; set; }
        public virtual ICollection<dtoItemCarrito> ItemCarrito { get; set; }



        public dtoProducto Crear(dtoProducto producto, int idUser)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoProducto, bizProducto>(producto);

            BIZ.CreatedBy = idUser;

            var repository = new ProductoRepository();
            repository.Insertar(BIZ);
            repository.Save();

            var nuevoProductoBIZ = repository.UltimoProducto();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<bizProducto, dtoProducto>(nuevoProductoBIZ);


            return DTO;
        }

        public object TraerProductos()
        {
            var repository = new ProductoRepository();
            var BIZ = repository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoProducto>>(BIZ);

            return DTO;
        }

        public dtoProducto BuscarUnProducto(int id)
        {
            var Repository = new ProductoRepository();
            var BIZ = Repository.TraerPorId(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<bizProducto, dtoProducto>(BIZ);

            return DTO;
        }

        public void Actualizar(dtoProducto DTO, int idUser)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoProducto, bizProducto>(DTO);

            BIZ.ChangedBy = idUser;

            var repo = new ProductoRepository();
            repo.Actualizar(BIZ);
            repo.Save();
        }

        public void Eliminar(dtoProducto dtopro)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();

            var BIZ = Mapper.Map<dtoProducto, bizProducto>(dtopro);

            var repo = new ProductoRepository();
            repo.Eliminar(BIZ);
            repo.Save();
        }
    }
}
