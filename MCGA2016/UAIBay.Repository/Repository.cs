using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAIBay.Repository
{
    public abstract class Repository<T>: IRepository<T> where T :class
    {

        protected readonly UAIBay.ORM.Context.UAIBayContext context= new ORM.Context.UAIBayContext();

        public  List<T> ObtenerTodos()
        {
            return context.Set<T>().ToList();
        }

        public T TraerPorId(int id)
        {
            return context.Set<T>().Find(id);
        }

        public   void Insertar(T objeto)
        {
             context.Set<T>().Add(objeto);
        }

        public   void Actualizar(T objeto)
        {
            context.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
        }

        public   void Eliminar(T objeto)
        {
            context.Set<T>().Remove(objeto);
        }

        public   void Save()
        {
            context.SaveChanges();
        }
    }
}
