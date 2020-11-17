using Capa_Datos;
using Capa_Logica;
using Capa_Presentacion.Filters;
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
    //Controlador IniciarSesionController
    public class IniciarSesionController : Controller
    {
        //Accion para el iniciar sesion
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para validar el acceso
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
                        //Tabla control
                        Session["cedula"] = Usuario.cedula;
                        Session["nombre"] = Usuario.nombre;
                        Session["apellido1"] = Usuario.apellido1;
                        Session["apellido2"] = Usuario.apellido2;
                        return RedirectToAction("Index", "Principal");
                    } else if (Usuario.IdRol == 2)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Editar Servicios Bibliotecarios";
                        //Tabla control
                        Session["cedula"] = Usuario.cedula;
                        Session["nombre"] = Usuario.nombre;
                        Session["apellido1"] = Usuario.apellido1;
                        Session["apellido2"] = Usuario.apellido2;
                        return RedirectToAction("Index", "Principal");
                    }
                    else if (Usuario.IdRol == 3)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Editar Consulta";
                        //Tabla control
                        Session["cedula"] = Usuario.cedula;
                        Session["nombre"] = Usuario.nombre;
                        Session["apellido1"] = Usuario.apellido1;
                        Session["apellido2"] = Usuario.apellido2;
                        return RedirectToAction("Index", "Principal");
                    }
                    else if (Usuario.IdRol == 4)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Editar Consultas CIIE";
                        //Tabla control
                        Session["cedula"] = Usuario.cedula;
                        Session["nombre"] = Usuario.nombre;
                        Session["apellido1"] = Usuario.apellido1;
                        Session["apellido2"] = Usuario.apellido2;
                        return RedirectToAction("Index", "Principal");
                    }
                    else if (Usuario.IdRol == 5)
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Editar Consultas CEDIL";
                        //Tabla control
                        Session["cedula"] = Usuario.cedula;
                        Session["nombre"] = Usuario.nombre;
                        Session["apellido1"] = Usuario.apellido1;
                        Session["apellido2"] = Usuario.apellido2;
                        return RedirectToAction("Index", "Principal");
                    } else
                    {
                        Session["Usuario"] = Usuario;
                        Session["nombreUsuario"] = Usuario.nombre + " " + Usuario.apellido1;
                        Session["Rol"] = "Consultar";
                        return RedirectToAction("Index", "Principal");
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
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para recuperar el acceso
        [HttpGet]
        public ActionResult Recuperar()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }

        //Accion para recuperar el acceso
        [HttpPost]
        public ActionResult Recuperar(string correo, string cedula)
        {
            try
            {
                using (var bd = new bibliotecaDataContext())
                {
                    int cantidad = bd.Usuario.Where(p => p.email == Seguridad.Encriptar(correo) && p.cedula == cedula).Count();
                    if (cantidad == 0)
                    {
                        //Mensaje de error
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

                        //Actualizamos la contraseña del usuario
                        clsUsuario clsUsuario = new clsUsuario();
                        clsUsuario.ActualizarUsuario(oUsuario.Id, oUsuario.cedula, oUsuario.nombre, oUsuario.apellido1, oUsuario.apellido2, oUsuario.email, contraEncriptada, oUsuario.IdRol);

                        //Enviamos el correo
                        Correo.enviarCorreo(correo, "Recuperar Clave", "Se reseteo su clave , ahora su clave es :" + nuevaContra, "");

                        //Mensaje de exito
                        TempData["msg"] = "<script>alert('Se ha enviado su nueva contraseña exitosamente al correo!');</script>";
                        return View("Index");
                    }
                }
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error500", "Error");
            }
        }
    }
}