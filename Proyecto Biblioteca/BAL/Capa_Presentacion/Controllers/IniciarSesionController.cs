using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class IniciarSesionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(string correo, string clave)
        {
            try
            {
                clsUsuario usuario = new clsUsuario();
                var objUsuario = usuario.Login(correo, clave);

                if (objUsuario.Count()>0)
                {
                    Session["User"] = objUsuario.First();
                    return RedirectToAction("Index", "Rol");
                }
                else
                {
                    return RedirectToAction("Index", "IniciarSesion");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }
    }
}