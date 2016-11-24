using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UAIBay.WebSite.Autorizaciones
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["LogedUserID"] != null)
            {
                if (HttpContext.Current.Session["LogedUserRol"].ToString() == "Administrador")
                {
                    return;
                }
            }
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}