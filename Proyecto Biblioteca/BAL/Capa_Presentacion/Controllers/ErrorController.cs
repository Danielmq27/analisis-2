using Capa_Presentacion.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador ErrorController
    [ValidarSesion]
    public class ErrorController : Controller
    {
        //Accion Error404
        [HttpGet]
        public ActionResult Error404()
        {
            return View();
        }

        //Accion Error500
        [HttpGet]
        public ActionResult Error500()
        {
            return View();
        }

        //Accion Error500
        [HttpGet]
        public ActionResult Regresar()
        {
            try
            {
                //Variable del rol
                string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                if (rol == "")
                {
                    return RedirectToAction("Index", "IniciarSesion");
                }
                else
                {
                    return RedirectToAction("Index", "Principal");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error505", "Error");
            }
        }
    }
}