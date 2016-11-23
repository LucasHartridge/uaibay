using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.BIZ;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;

namespace UAIBay.Repository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        private readonly UAIBayContext contexto = new UAIBayContext();

        public List<bizUsuario> ObtenerTodos()
        {

            var orm = contexto.Usuarios.Where(x => x.IsDeleted == false).ToList();

            Mapeador.AutoMapperORMConfiguration.Configure();
            var BIZ = Mapper.Map<List<bizUsuario>>(orm);
            return BIZ;
        }

        public bizUsuario TraerPorEmail(string email)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = contexto.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            var biz = Mapper.Map<Usuario, bizUsuario>(orm);

            return biz;
        }

        public bizUsuario UltimoUsuario()
        {
            var todos = ObtenerTodos();

            var maxZ = todos.Max(obj => obj.UserId);
            var maxObj = todos.Where(obj => obj.UserId == maxZ).FirstOrDefault();

            return maxObj;
        }

        public bizUsuario TraerCuenta(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = contexto.Usuarios.Find(id);
            var biz = Mapper.Map<Usuario, bizUsuario>(orm);

            return biz;
        }


        public void Insertar(bizUsuario objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = Mapper.Map<bizUsuario, Usuario>(objeto);

            contexto.Usuarios.Add(orm);
        }

        public void Actualizar(bizUsuario objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = Mapper.Map<bizUsuario, Usuario>(objeto);
            contexto.Entry(orm).State = System.Data.Entity.EntityState.Modified;
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
