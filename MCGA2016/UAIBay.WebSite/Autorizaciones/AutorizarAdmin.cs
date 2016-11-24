using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Web.Mvc;

namespace UAIBay.WebSite.Autorizaciones
{
    public class AutorizarAdmin : AuthorizeAttribute, IAuthorizationFilter
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["LogedUserID"] != null)
            {
                if (HttpContext.Current.Session["LogedUserRol"].ToString() == "Administrador")
                {
                    return;
                }
                else
                {
                    throw new HttpException(403, "HTTPExcepcion403");
                }
            }
            else
            {
                throw new HttpException(403, "HTTPExcepcion403");
            }

        }

    }

}