using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.Repository;
using UAIBay.BIZ;

namespace UAIBay.BLL.DTO
{
    public class dtoProveedor
    {
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public virtual ICollection<dtoCompra> Compra { get; set; }


        public object TraerProveedores()
        {
            var provRepository = new ProveedorRepository();
            var proveedoresBIZ = provRepository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var proveedoresDTO = Mapper.Map<List<dtoProveedor>>(proveedoresBIZ);

            return proveedoresDTO;
        }

        public void Crear(dtoProveedor dtoProveedor)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoProveedor, bizProveedor>(dtoProveedor);

            var repository = new ProveedorRepository();
            repository.Insertar(BIZ);
            repository.Save();
        }

        public dtoProveedor BuscarUnProveedor(string id)
        {
            var Repository = new ProveedorRepository();
            var BIZ = Repository.TraerPorId(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<bizProveedor,dtoProveedor >(BIZ);

            return DTO;
        }

        public void Actualizar(dtoProveedor dtoProve)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoProveedor, bizProveedor>(dtoProve);

            var repo = new ProveedorRepository();
            repo.Actualizar(BIZ);
            repo.Save();
        }


        public void Eliminar(dtoProveedor dtoProve)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();

            var BIZ = Mapper.Map<dtoProveedor, bizProveedor>(dtoProve);

            var repo = new ProveedorRepository();
            repo.Eliminar(BIZ);
            repo.Save();
        }
    }
}
