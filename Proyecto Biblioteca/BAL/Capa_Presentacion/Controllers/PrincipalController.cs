using Capa_Datos;
using Capa_Logica;
using Capa_Presentacion.Filters;
using Capa_Presentacion.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    //Controlador PrincipalController
    [ValidarSesion]
    public class PrincipalController : Controller
    {
        //Accion para el rol administrador
        [Acceso]
        public ActionResult Administrador()
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

        //Accion para el rol editar
        [Acceso]
        public ActionResult Editar()
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

        //Accion para el rol consultar
        [Acceso]
        public ActionResult Consultar()
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

        //Accion para cerarr sesion
        [Acceso]
        public ActionResult CerrarSesion()
        {
            try
            {
                //Variable del rol
                string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                if (rol == "Administrador")
                {
                    Session["Usuario"] = null;
                    Session["nombreUsuario"] = null;
                    Session["Rol"] = null;
                    //Tabla control
                    Session["cedula"] = null;
                    Session["nombre"] = null;
                    Session["apellido1"] = null;
                    Session["apellido2"] = null;
                    return RedirectToAction("Index", "IniciarSesion");
                }
                else if (rol == "Editar")
                {
                    Session["Usuario"] = null;
                    Session["nombreUsuario"] = null;
                    Session["Rol"] = null;
                    //Tabla control
                    Session["cedula"] = null;
                    Session["nombre"] = null;
                    Session["apellido1"] = null;
                    Session["apellido2"] = null;
                    return RedirectToAction("Index", "IniciarSesion");
                }
                else
                {
                    Session["Usuario"] = null;
                    Session["nombreUsuario"] = null;
                    Session["Rol"] = null;
                    return RedirectToAction("Index", "IniciarSesion");
                }
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error505", "Error");
            }
        }

        //Accion para cambiar la clave
        [Acceso]
        public ActionResult Cambiar(string ClaveTemporal, string Clave, string ClaveConfirmar)
        {
            try
            {
                using (var bd = new bibliotecaDataContext())
                {
                    string claveActual = Seguridad.Encriptar(ClaveTemporal);
                    int cantidad = bd.Usuario.Where(p => p.clave == claveActual).Count();
                    if (cantidad == 0)
                    {
                        //Variable del rol
                        string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                        if(rol == "Administrador")
                        {
                            //Mensaje de error
                            TempData["msg"] = "<script>alert('Cedula incorrecta');</script>";
                            return RedirectToAction("Administrador", "Principal");
                        }
                        else if (rol == "Editar")
                        {
                            //Mensaje de error
                            TempData["msg"] = "<script>alert('Cedula incorrecta');</script>";
                            return RedirectToAction("Editar", "Principal");
                        } 
                        else
                        {
                            //Mensaje de error
                            TempData["msg"] = "<script>alert('Cedula incorrecta');</script>";
                            return RedirectToAction("Consultar", "Principal");
                        }
                    } 
                    else
                    {
                        //Se recupera el id del Usuario
                        Usuario oUsuario = bd.Usuario.Where(p => p.clave == claveActual).First();

                        //Comparacion de claves
                        if(Clave == ClaveConfirmar)
                        {
                            //Nueva clave 
                            string claveNueva = Seguridad.Encriptar(Clave);

                            //Actualizamos usuario
                            clsUsuario usuario = new clsUsuario();
                            usuario.ActualizarUsuario(oUsuario.Id, oUsuario.cedula, oUsuario.nombre, oUsuario.apellido1, oUsuario.apellido2, oUsuario.email, claveNueva, oUsuario.IdRol);

                            //Variable del rol
                            string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                            if (rol == "Administrador")
                            {
                                //Mensaje de exito
                                TempData["msg"] = "<script>alert('Exito! Se ha cambiado la contraseña');</script>";
                                return RedirectToAction("Administrador", "Principal");
                            }
                            else if (rol == "Editar")
                            {
                                //Mensaje de exito
                                TempData["msg"] = "<script>alert('Exito! Se ha cambiado la contraseña');</script>";
                                return RedirectToAction("Editar", "Principal");
                            }
                            else
                            {
                                //Mensaje de exito
                                TempData["msg"] = "<script>alert('Exito! Se ha cambiado la contraseña');</script>";
                                return RedirectToAction("Consultar", "Principal");
                            }
                        }
                        else
                        {
                            //Variable del rol
                            string rol = System.Web.HttpContext.Current.Session["Rol"] as String;
                            if (rol == "Administrador")
                            {
                                //Mensaje de error
                                TempData["msg"] = "<script>alert('Contraseñas no son iguales');</script>";
                                return RedirectToAction("Administrador", "Principal");
                            }
                            else if (rol == "Editar")
                            {
                                //Mensaje de error
                                TempData["msg"] = "<script>alert('Contraseñas no son iguales');</script>";
                                return RedirectToAction("Editar", "Principal");
                            }
                            else
                            {
                                //Mensaje de error
                                TempData["msg"] = "<script>alert('Contraseñas no son iguales');</script>";
                                return RedirectToAction("Consultar", "Principal");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Pagina de Error
                return RedirectToAction("Error505", "Error");
            }
        }
    }
}