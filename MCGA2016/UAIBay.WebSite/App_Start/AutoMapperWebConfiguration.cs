using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAIBay.BLL.DTO;
using AutoMapper;
using UAIBay.WebSite.ViewModel;

namespace UAIBay.WebSite.App_Start
{
    public static class AutoMapperWebConfiguration
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
            base.CreateMap<CategoriaViewModels, dtoCategoria>().ReverseMap();
            base.CreateMap<CompraViewModels, dtoCompra>().ReverseMap();
            base.CreateMap<DetalleCompraViewModels, dtoDetalleCompra>().ReverseMap();
            base.CreateMap<DetalleVentaViewModels, dtoDetalleVenta>().ReverseMap();
            base.CreateMap<DireccionViewModels, dtoDireccion>().ReverseMap();
            base.CreateMap<ProductoViewModels, dtoProducto>().ReverseMap();
            base.CreateMap<PromocionViewModels, dtoPromocion>().ReverseMap();
            base.CreateMap<ProveedorViewModels, dtoProveedor>().ReverseMap();
            base.CreateMap<RolesViewModels, dtoRoles>().ReverseMap();
            base.CreateMap<TarjetaCreditoViewModels, dtoTarjetaCredito>().ReverseMap();
            base.CreateMap<UsuarioViewModels, dtoUsuario>().ReverseMap();
            base.CreateMap<VentaViewModels, dtoVenta>().ReverseMap();
        }
    }
}