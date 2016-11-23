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
    public class DireccionRepository : Repository<Direccion>
    {
        private readonly UAIBayContext contexto = new UAIBayContext();



        public List<bizDireccion> ObtenerTodos(int idUsuario)
        {

            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Direcciones.Where(X => X.UserId == idUsuario).ToList();

            var BIZ = Mapper.Map<List<bizDireccion>>(ORM);

            return BIZ;

        }


        public bizDireccion TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Direcciones.Find(id);
            var BIZ = Mapper.Map<Direccion, bizDireccion>(ORM);

            return BIZ;
        }

        public void Insertar(bizDireccion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizDireccion, Direccion>(objeto);

            contexto.Direcciones.Add(ORM);
        }

        public void Actualizar(bizDireccion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizDireccion, Direccion>(objeto);
            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizDireccion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Direccion Direcciones = (Direccion)contexto.Direcciones.Where(b => b.IDDireccion == objeto.IDDireccion).First();
            contexto.Direcciones.Remove(Direcciones);
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
