using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using UAIBay.ORM.Context;

namespace UAIBay.Repository
{
    public interface IRepository<T> where T : class
    {

        List<T> ObtenerTodos();

        T TraerPorId(int id);

        void Insertar(T objeto);
        void Actualizar(T objeto);
        void Eliminar(T objeto);
        void Save();


    }
  
}
