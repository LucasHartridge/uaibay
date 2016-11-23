using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.BIZ;
using UAIBay.Repository;

namespace UAIBay.BLL.DTO
{
    public class dtoPromocion
    {
        public int CodPromocion { get; set; }
        public string Nro { get; set; }
        public int Descuento { get; set; }
        public System.DateTime FechaVencimiento { get; set; }


        public List<dtoPromocion> TraerPromociones()
        {
            var repo = new PromocionRepository();
            var biz = repo.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoPromocion>>(biz);

            return DTO;
        }

        public void Crear(dtoPromocion dtoPromocion)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var biz = Mapper.Map<dtoPromocion, bizPromocion>(dtoPromocion);

            var repo = new PromocionRepository();
            repo.Insertar(biz);
            repo.Save();

        }

        public dtoPromocion BuscarPromocion(int id)
        {
            var repo = new PromocionRepository();
            var biz = repo.TraerPorId(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var dto = Mapper.Map<bizPromocion, dtoPromocion>(biz);

            return dto;
        }

        public void Actualizar(dtoPromocion dtoPromocion)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var biz = Mapper.Map<dtoPromocion, bizPromocion>(dtoPromocion);

            var repo = new PromocionRepository();
            repo.Actualizar(biz);
            repo.Save();
        }

        public void Eliminar(dtoPromocion dtoPromocion)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();

            var biz = Mapper.Map<dtoPromocion, bizPromocion>(dtoPromocion);

            var repo = new PromocionRepository();
            repo.Eliminar(biz);
            repo.Save();
        }
    }
}
