using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UAIBay.WebSite.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //    //filters.Add(new RequireHttpsAttribute());
        //}
    }
}

