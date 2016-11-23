﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Mvc;

namespace UAIBay.WebSite.Autorizaciones
{
    public class AutorizarUsuarioYAdmin : AuthorizeAttribute, IAuthorizationFilter
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["LogedUserRol"] == "Administrador" | HttpContext.Current.Session["LogedUserRol"] == "Cliente")
            {
                return;
            }
            throw new HttpException(403, "HTTPExcepcion403");
            //filterContext.Result = New HttpUnauthorizedResult()
        }

    }
}