using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador ErrorController
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
                if (rol == "Administrador")
                {
                    return RedirectToAction("Administrador", "Principal");
                } 
                else if (rol == "Editar")
                {
                    return RedirectToAction("Editar", "Principal");
                }
                else if (rol == "Consultar")
                {
                    return RedirectToAction("Consultar", "Principal");
                }
                else
                {
                    return RedirectToAction("Index", "IniciarSesion");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error505", "Error");
            }
        }
    }
}