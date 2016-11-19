using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;
using UAIBay.BIZ;
using AutoMapper;

namespace UAIBay.Repository
{
    public class RolesRepository : Repository<Roles>
    {

        private readonly UAIBayContext contexto = new UAIBayContext();



        public List<bizRoles> ObtenerTodos()
        {

            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Roles.ToList();

            var BIZ = Mapper.Map<List<bizRoles>>(ORM);

            return BIZ;

        }


        public bizRoles TraerRolCliente()
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Roles.Where(x=> x.Nombre=="Cliente").FirstOrDefault();
            var BIZ = Mapper.Map<Roles, bizRoles>(ORM);

            return BIZ;
        }


        public bizRoles TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Roles.Find(id);
            var BIZ = Mapper.Map<Roles, bizRoles>(ORM);

            return BIZ;
        }

        public void Insertar(bizRoles objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizRoles, Roles>(objeto);

            contexto.Roles.Add(ORM);
        }

        public void Actualizar(bizRoles objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizRoles, Roles>(objeto);
            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizRoles objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Roles roles = (Roles)contexto.Roles.Where(b => b.IdRol == objeto.IdRol).First();
            contexto.Roles.Remove(roles);
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
