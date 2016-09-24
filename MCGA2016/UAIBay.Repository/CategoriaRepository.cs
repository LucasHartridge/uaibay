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
           return contexto.Categorias.Find(id);
       }

       public  void Insertar(Categoria objeto)
       {
           contexto.Categorias.Add(objeto);
       }

       public  void Actualizar(Categoria objeto)
       {
           contexto.Entry(objeto).State= System.Data.Entity.EntityState.Modified;
       }

       public  void Eliminar(Categoria objeto)
       {
           contexto.Categorias.Remove(objeto);
       }

       public  void Save()
       {
           contexto.SaveChanges();
       }
    }
}
