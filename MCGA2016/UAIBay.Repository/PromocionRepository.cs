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
    public class PromocionRepository : Repository<Promocion>
    {
          private readonly UAIBayContext contexto = new UAIBayContext();



        public List<bizPromocion> ObtenerTodos()
        {

                Mapeador.AutoMapperORMConfiguration.Configure();
                var ORM = contexto.Promociones.ToList();

                var BIZ = Mapper.Map<List<bizPromocion>>(ORM);

                return BIZ;

        }

        public bizPromocion TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Promociones.Find(id);
            var BIZ = Mapper.Map<Promocion, bizPromocion>(ORM);

            return BIZ;
        }

        public void Insertar(bizPromocion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizPromocion, Promocion>(objeto);

            contexto.Promociones.Add(ORM);
        }

        public void Actualizar(bizPromocion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizPromocion, Promocion>(objeto);
            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizPromocion objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            Promocion Promocion = (Promocion)contexto.Promociones.Where(b => b.CodPromocion == objeto.CodPromocion).First();
            contexto.Promociones.Remove(Promocion);
            contexto.SaveChanges();
        }

        public void Save()
        {
            contexto.SaveChanges();
        }
    }
    
}
