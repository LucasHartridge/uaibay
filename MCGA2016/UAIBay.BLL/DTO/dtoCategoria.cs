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
    public class dtoCategoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<dtoProducto> Producto { get; set; }

        public object TraerCategorias()
        {
            var catRepository = new CategoriaRepository();
            var categoriasBIZ = catRepository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var categoriasDTO =  Mapper.Map<List<dtoCategoria>>(categoriasBIZ);

            return categoriasDTO;
        }

        public void Crear(dtoCategoria dtoCategoria)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var categoriaBIZ = Mapper.Map<dtoCategoria,bizCategoria>(dtoCategoria);

            var catRepository = new CategoriaRepository();
            catRepository.Insertar(categoriaBIZ);
            catRepository.Save();
          
        }

        public dtoCategoria BuscarCategoria(int id)
        {
            var catRepository = new CategoriaRepository();
            var categoriasBIZ = catRepository.TraerPorId(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var categoriasDTO = Mapper.Map<bizCategoria, dtoCategoria>(categoriasBIZ);

            return categoriasDTO;
        }

        public void Actualizar(dtoCategoria dtoCategoria)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var categoriaBIZ = Mapper.Map<dtoCategoria, bizCategoria>(dtoCategoria);

            var catRepository = new CategoriaRepository();
            catRepository.Actualizar(categoriaBIZ);
            catRepository.Save();
        }

        public void Eliminar(dtoCategoria dtoCategoria)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();

            var categoriaBIZ = Mapper.Map<dtoCategoria, bizCategoria>(dtoCategoria);

            var catRepository = new CategoriaRepository();
            catRepository.Eliminar(categoriaBIZ);
            catRepository.Save();
        }
    }
}
