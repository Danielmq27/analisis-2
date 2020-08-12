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
                var oUsuario = usuario.Login(Seguridad.Encriptar(correo), Seguridad.Encriptar(clave));
                if(oUsuario.Count > 0)
                {
                    var Usuario = oUsuario.First();
                    if (Usuario.IdRol == 1)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Administrador";
                        return RedirectToAction("Administrador", "Principal");
                    }else if (Usuario.IdRol == 2)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Editar";
                        return RedirectToAction("Editar", "Principal");
                    } else
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Consultar";
                        return RedirectToAction("Consultar", "Principal");
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('Correo o contraseña incorrectos');</script>";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recuperar(string correo, string cedula)
        {
            using(var bd = new bibliotecaDataContext())
            {
                int cantidad = bd.Usuario.Where(p => p.email == Seguridad.Encriptar(correo) && p.cedula == cedula).Count();
                if (cantidad == 0)
                {
                    TempData["msg"] = "<script>alert('Usuario no existe');</script>";
                    return View("Recuperar");
                }
                else
                {
                    //Se recupera el id del Usuario
                    Usuario oUsuario = bd.Usuario.Where(p => p.email == Seguridad.Encriptar(correo) && p.cedula == cedula).First();

                    //Nueva clave
                    Random ra = new Random();
                    int n1 = ra.Next(0, 9);
                    int n2 = ra.Next(0, 9);
                    int n3 = ra.Next(0, 9);
                    int n4 = ra.Next(0, 9);
                    string nuevaContra = n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString();

                    //Encriptar la nueva clave
                     string contraEncriptada = Seguridad.Encriptar(nuevaContra);

                    oUsuario.clave = contraEncriptada;
                    Correo.enviarCorreo(correo, "Recuperar Clave", "Se reseteo su clave , ahora su clave es :" + nuevaContra, " ");
                    TempData["msg"] = "<script>alert('Se ha enviado su nueva contraseña exitosamente al correo!');</script>";
                    return View("Index");
                }
            }
        }
    }
}