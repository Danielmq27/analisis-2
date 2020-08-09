using Capa_Datos;
using Capa_Logica;
using Capa_Presentacion.Models;
using Capa_Presentacion.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuario = Capa_Datos.Usuario;

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
                var oUsuario = usuario.Login(Seguridad.Encriptar(correo), Seguridad.Encriptar(clave)).First();
                if (oUsuario == null)
                {
                    TempData["msg"] = "<script>alert('Correo o contraseña incorrectos');</script>";
                    return View("Index");
                }
                else if (oUsuario.IdRol == 1)
                {
                    Session["Usuario"] = oUsuario;
                    Session["nombreUsuario"] = oUsuario.nombre + " " + oUsuario.apellido1;
                    Session["Rol"] = "Administrador";
                    return RedirectToAction("Administrador", "Principal");
                } 
                else if (oUsuario.IdRol == 2)
                {
                    Session["Usuario"] = oUsuario;
                    Session["nombreUsuario"] = oUsuario.nombre + " " + oUsuario.apellido1;
                    Session["Rol"] = "Editar";
                    return RedirectToAction("Editar", "Principal");
                } 
                else
                {
                    Session["Usuario"] = oUsuario;
                    Session["nombreUsuario"] = oUsuario.nombre + " " + oUsuario.apellido1;
                    Session["Rol"] = "Consultar";
                    return RedirectToAction("Consultar", "Principal");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }
    }
}