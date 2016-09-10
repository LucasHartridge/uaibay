using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;
using System.Data.Entity;

namespace UAIBay.Repository
{
   public class CategoriaRepository: Repository<Categoria>
    {

       private readonly UAIBayContext contexto = new UAIBayContext();


       public  List<Categoria> ObtenerTodos()
       {
           return contexto.Categorias.ToList();
       }

       public  Categoria TraerPorId(int id)
       {
           throw new NotImplementedException();
       }

       public  void Insertar(Categoria objeto)
       {
           throw new NotImplementedException();
       }

       public  void Actualizar(Categoria objeto)
       {
           throw new NotImplementedException();
       }

       public  void Eliminar(Categoria objeto)
       {
           throw new NotImplementedException();
       }

       public  void Save()
       {
           throw new NotImplementedException();
       }
    }
}
