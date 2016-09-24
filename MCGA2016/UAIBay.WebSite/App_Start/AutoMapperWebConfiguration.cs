using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAIBay.ORM.Business;
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
                cfg.AddProfile(new CategoriaProfile());
            });
        }
    }

    public class CategoriaProfile : Profile
    {
        protected override void Configure()
        {
            base.CreateMap<CategoriaViewModels, Categoria>().ReverseMap();      
        }
    }
}