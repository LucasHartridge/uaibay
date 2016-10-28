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

            var orm = contexto.Productos.Where(x => x.IsDeleted == false).ToList();

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

            var todos = ObtenerTodos();

            if (todos.Count==0)
            {
                objeto.Imagen = "1";
            }
            else
            {
                var maxZ = todos.Max(obj => obj.CodProducto);
                var maxObj = todos.Where(obj => obj.CodProducto == maxZ).FirstOrDefault();

                objeto.Imagen = Convert.ToString(maxObj.CodProducto + 1);
            }

            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizProducto, Producto>(objeto);

            ORM.CreatedOn = DateTime.Now;
            ORM.CreatedBy = 1;

            contexto.Productos.Add(ORM);
        }

        public void Actualizar(bizProducto newObject)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            var original = BuscarUnORMProducto(newObject.CodProducto);

            original.Categoria = new Categoria { IdCategoria = newObject.IdCategoria };

            original.ChangedBy = 1;
            original.ChangedOn = DateTime.Now;
            original.IdCategoria = newObject.IdCategoria;
            original.DeletedOn = newObject.DeletedOn;
            original.Descripcion = newObject.Descripcion;
            original.Imagen = newObject.Imagen;
            original.IsDeleted = newObject.IsDeleted;
            original.PrecioCompra = newObject.PrecioCompra;
            original.PrecioVenta = newObject.PrecioVenta;

            contexto.Entry(original).State = System.Data.Entity.EntityState.Modified;
        }

        public Producto BuscarUnORMProducto(int id)
        {
            var Repository = new ProductoRepository();
            var BIZ = Repository.TraerPorId(id);

            var ORM = Mapper.Map<bizProducto, Producto>(BIZ);
            return ORM;
        }

        public void Eliminar(bizProducto objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Producto Producto = (Producto)contexto.Productos.Where(b => b.CodProducto == objeto.CodProducto).First();

            Producto.DeletedOn = DateTime.Now;
            Producto.IsDeleted = true;

            contexto.Entry(Producto).State = System.Data.Entity.EntityState.Modified;
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
