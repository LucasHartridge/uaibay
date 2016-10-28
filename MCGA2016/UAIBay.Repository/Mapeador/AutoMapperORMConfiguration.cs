using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.ORM.Business;
using UAIBay.BIZ;

namespace UAIBay.Repository.Mapeador
{
    public class AutoMapperORMConfiguration
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
            base.CreateMap<Categoria, bizCategoria>().ReverseMap();
            base.CreateMap<Compra, bizCompra>().ReverseMap();
            base.CreateMap<DetalleCompra, bizDetalleCompra>().ReverseMap();
            base.CreateMap<DetalleVenta, bizDetalleVenta>().ReverseMap();
            base.CreateMap<Direccion, bizDireccion>().ReverseMap();
            base.CreateMap<Producto, bizProducto>().ReverseMap();
            base.CreateMap<Promocion, bizPromocion>().ReverseMap();
            base.CreateMap<Proveedor, bizProveedor>().ReverseMap();
            base.CreateMap<Roles, bizRoles>().ReverseMap();
            base.CreateMap<TarjetaCredito, bizTarjetaCredito>().ReverseMap();
            base.CreateMap<Usuario, bizUsuario>().ReverseMap();
            base.CreateMap<Venta, bizVenta>().ReverseMap();
            base.CreateMap<Carrito, bizCarrito>().ReverseMap();
            base.CreateMap<ItemCarrito, bizItemCarrito>().ReverseMap();
        }
    }
}
