using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.BLL.DTO;
using UAIBay.BIZ;

namespace UAIBay.BLL.Mapeador
{
    public class AutoMapperBLLConfiguration
    {
        public static void Configure()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new Mapeos());
            });

        }
    }

    public class Mapeos : Profile
    {
        protected override void Configure()
        {
            base.CreateMap<dtoCategoria, bizCategoria>().ReverseMap();
            base.CreateMap<dtoCompra, bizCompra>().ReverseMap();
            base.CreateMap<dtoDetalleCompra, bizDetalleCompra>().ReverseMap();
            base.CreateMap<dtoDetalleVenta, bizDetalleVenta>().ReverseMap();
            base.CreateMap<dtoDireccion, bizDireccion>().ReverseMap();
            base.CreateMap<dtoProducto, bizProducto>().ReverseMap();
            base.CreateMap<dtoPromocion, bizPromocion>().ReverseMap();
            base.CreateMap<dtoProveedor, bizProveedor>().ReverseMap();
            base.CreateMap<dtoRoles, bizRoles>().ReverseMap();
            base.CreateMap<dtoTarjetaCredito, bizTarjetaCredito>().ReverseMap();
            base.CreateMap<dtoUsuario, bizUsuario>().ReverseMap();
            base.CreateMap<dtoVenta, bizVenta>().ReverseMap();
            base.CreateMap<dtoCarrito, bizCarrito>().ReverseMap();
            base.CreateMap<dtoItemCarrito, bizItemCarrito>().ReverseMap();
        }
    }


}
