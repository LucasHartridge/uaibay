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
using System.Reflection;

namespace UAIBay.Repository
{
    public class ProveedorRepository : Repository<Proveedor>
    {
        private readonly UAIBayContext contexto = new UAIBayContext();


        public List<bizProveedor> ObtenerTodos()
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Proveedores.ToList().Where(x=> x.IsDeleted==false);
            var BIZ = Mapper.Map<List<bizProveedor>>(ORM);

            return BIZ;
        }

        public bizProveedor TraerPorId(string id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Proveedores.Find(id);
            var BIZ = Mapper.Map<Proveedor, bizProveedor>(ORM);
            return BIZ;
        }

        public void Insertar(bizProveedor objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizProveedor, Proveedor>(objeto);

            ORM.CreatedBy = 1;
            ORM.CreatedOn = DateTime.Now;
            ORM.IsDeleted = false;

            contexto.Proveedores.Add(ORM);
        }

        public Proveedor BuscarUnORMProveedor(string id)
        {
            var Repository = new ProveedorRepository();
            var BIZ = Repository.TraerPorId(id);

            var ORM = Mapper.Map<bizProveedor, Proveedor>(BIZ);
            return ORM;
        }

        public void Actualizar(bizProveedor newObject)
        {

            Mapeador.AutoMapperORMConfiguration.Configure();

            var original = BuscarUnORMProveedor(newObject.CUIT);

            original.ChangedBy = 1;
            original.ChangedOn = DateTime.Now;
            original.CodigoPostal = newObject.CodigoPostal;
            original.DeletedOn = newObject.DeletedOn;
            original.Domicilio = newObject.Domicilio;
            original.Email = newObject.Email;
            original.IsDeleted = newObject.IsDeleted;
            original.Localidad = newObject.Localidad;
            original.Nombre = newObject.Nombre;
            original.Telefono = newObject.Telefono;

            contexto.Entry(original).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizProveedor objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Proveedor Proveedor = (Proveedor)contexto.Proveedores.Where(b => b.CUIT == objeto.CUIT).First();

            Proveedor.DeletedOn = DateTime.Now;
            Proveedor.IsDeleted = true;

            contexto.Entry(Proveedor).State = System.Data.Entity.EntityState.Modified;

            //contexto.Proveedores.Remove(Proveedor);
            //contexto.SaveChanges();
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
