using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;
using System.Data.Entity;
using UAIBay.BIZ;
using AutoMapper;

namespace UAIBay.Repository
{
    public class CategoriaRepository : Repository<Categoria>
    {

        private readonly UAIBayContext contexto = new UAIBayContext();



        public List<bizCategoria> ObtenerTodos()
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var categoriasORM = contexto.Categorias.ToList();
            var categoriasBIZ = Mapper.Map<List<bizCategoria>>(categoriasORM);

            return categoriasBIZ;
        }

        public bizCategoria TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var categoriaORM = contexto.Categorias.Find(id);
            var categoriaBIZ = Mapper.Map<Categoria, bizCategoria>(categoriaORM);

            return categoriaBIZ;
        }

        public void Insertar(bizCategoria objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var categoriaORM = Mapper.Map<bizCategoria, Categoria>(objeto);

            contexto.Categorias.Add(categoriaORM);
        }

        public void Actualizar(bizCategoria objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var categoriaORM = Mapper.Map<bizCategoria, Categoria>(objeto);
            contexto.Entry(categoriaORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizCategoria objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Categoria categoria = (Categoria)contexto.Categorias.Where(b => b.IdCategoria == objeto.IdCategoria).First();
            contexto.Categorias.Remove(categoria);
            contexto.SaveChanges();
        }

        public void Save()
        {
            contexto.SaveChanges();
        }
    }
}
