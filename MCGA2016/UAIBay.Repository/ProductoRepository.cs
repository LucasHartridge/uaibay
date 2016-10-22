using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;
using UAIBay.BIZ;


namespace UAIBay.Repository
{
    public class ProductoRepository : Repository<Producto>
    {


        private readonly UAIBayContext contexto = new UAIBayContext();



        public List<bizProducto> ObtenerTodos()
        {

            var orm = contexto.Productos.ToList();

            Mapeador.AutoMapperORMConfiguration.Configure();
            var BIZ = Mapper.Map<List<bizProducto>>(orm);
            return BIZ;
        }

        public bizProducto TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Productos.Find(id);
            var BIZ = Mapper.Map<Producto, bizProducto>(ORM);

            return BIZ;
        }

        public void Insertar(bizProducto objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizProducto, Producto>(objeto);
            ORM.CreatedOn = DateTime.Now;
            ORM.CreatedBy = 1;

            contexto.Productos.Add(ORM);
        }

        public void Actualizar(bizProducto objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizProducto, Producto>(objeto);
            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizProducto objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Producto producto = (Producto)contexto.Productos.Where(b => b.CodProducto == objeto.CodProducto).First();
            contexto.Productos.Remove(producto);
            contexto.SaveChanges();
        }

        public void Save()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }














    }
}
