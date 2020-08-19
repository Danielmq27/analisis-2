using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capa_Presentacion.Filters
{
    public class Acceso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    //Variable del rol
                    string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                    if (rol == "Administrador")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Principal", action = "Administrador", area = "" }));
                    }
                    else if (rol == "Editar")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Principal", action = "Editar", area = "" }));
                    }
                    else if (rol == "Consultar")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Principal", action = "Consultar", area = "" }));
                    } else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "IniciarSesion", action = "Index", area = "" }));
                    }
                }
        }
    }
}